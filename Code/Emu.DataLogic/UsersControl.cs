using Emu.Common;
using Emu.DataLogic.Properties;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Emu.DataLogic
{
    public class UsersControl : IUsersControl
    {
        #region Properties
        
        MySqlConnection Connection { get; set; }

        struct SQL
        {
            public const string Get  = @"SELECT
                                                    ID,
                                                    Type,
                                                    Username,
                                                    PasswordHash 
                                            FROM 
                                                    EmuUser";
            
            public const string GetByID = @"SELECT 
                                                    ID,
                                                    Type,
                                                    Username,
                                                    PasswordHash
                                            FROM 
                                                    EmuUser 
                                            WHERE 
                                                    ID = @ID";
            
            public const string GetByUsername = @"  SELECT
                                                            ID,
                                                            Type,
                                                            Username,
                                                            PasswordHash
                                                    FROM 
                                                            EmuUser 
                                                    WHERE 
                                                            Username = @Username";
            
            public const string Create  = @"INSERT INTO EmuUser 
                                            (
                                                    Type,
                                                    Username,
                                                    PasswordHash
                                            ) 
                                            VALUES 
                                            (
                                                    @Type, 
                                                    @Username, 
                                                    @PasswordHash
                                            )";
            
            public const string Update  = @"UPDATE 
                                                    EmuUser 
                                            SET 
                                                    Type = @Type, 
                                                    Username = @Username, 
                                                    PasswordHash = @PasswordHash
                                            WHERE 
                                                    ID = @ID";
        }

        #endregion
        #region Constructor

        public UsersControl()
        {
            Connection = new MySqlConnection( Settings.Default.ConnectionString ); 
        }

        #endregion
        #region Methods
        
        public List<User> Get()
        {
            var result = new List<User>();

            Connection.Open();
            using (var cmd = new MySqlCommand(SQL.Get, Connection))
            {
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        result.Add( new User
                        {
                            ID = Convert.ToInt32(reader[ "ID" ].ToString()) ,
                            Type = Convert.ToInt32(reader["Type"].ToString()).ToEnum(UserType.BasicUser),
                            UserName = reader["Username"].ToString(),
                            PasswordHash = reader["PasswordHash"].ToString()
                        });
                    }
                }
            }
            Connection.Close();

            return result;
        }

        public User Get( int id )
        {
            #region Validate Arguments

            if (id.IsPositive() == false)
            {
                throw new ArgumentException("The id argument must be a positive integer.", "id");
            }

            #endregion

            User result = null;

            Connection.Open();
            using (var cmd = new MySqlCommand(SQL.GetByID, Connection))
            {
                cmd.Parameters.AddWithValue("@ID", id);

                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        result = new User
                        {
                            ID = Convert.ToInt32(reader["ID"]),
                            Type = Convert.ToInt32(reader["Type"].ToString()).ToEnum(UserType.BasicUser),
                            UserName = reader["Username"].ToString(),
                            PasswordHash = reader["PasswordHash"].ToString()
                        };
                    }
                }
            }
            Connection.Close();
            
            return result;
        }

        public void Create( User user )
        {
            #region Validate Arguments

            if( user == null )
            {
                throw new ArgumentException( "User argument must not be null.", "user" );
            }

            if( string.IsNullOrWhiteSpace( user.UserName ) )
            {
                throw new ArgumentException( "Username cannot be null or empty", "username" );
            }

            #endregion

            Connection.Open();
            using (var cmd = new MySqlCommand(SQL.Create, Connection))
            {
                cmd.Parameters.AddWithValue("@Type", user.Type);
                cmd.Parameters.AddWithValue("@Username", user.UserName);
                cmd.Parameters.AddWithValue("@PasswordHash", "no password yet");

                // run the update statement
                cmd.ExecuteNonQuery();
            }
            Connection.Close();

        }

        public void Update( User user )
        {
            #region Validate Arguments
            
            if( user == null )
            {
                throw new ArgumentException("User argument must not be null.", "user");
            }
            if( user.ID.IsPositive() == false )
            {
                throw new ArgumentException("User ID must be a positive integer.", "id");
            }

            #endregion

            Connection.Open();
            using (var cmd = new MySqlCommand(SQL.Update, Connection))
            {
                cmd.Parameters.AddWithValue("@ID", user.ID);
                cmd.Parameters.AddWithValue("@Type", user.Type);
                cmd.Parameters.AddWithValue("@Username", user.UserName);
                cmd.Parameters.AddWithValue("@PasswordHash", user.PasswordHash);

                // run the update statement
                cmd.ExecuteNonQuery();
            }
            Connection.Close();
        }

        public User Authenticate( string userName, string password )
        {
            #region Validate Arguments

            if( String.IsNullOrWhiteSpace(userName) )
            {
                throw new ArgumentException("User Name argument must not be null.", "userName");
            }
            if( String.IsNullOrWhiteSpace(password) )
            {
                throw new ArgumentException("Password Name argument must not be null.", "passwrd");
            }

            #endregion

            User user = null;

            Connection.Open();
            using( var cmd = new MySqlCommand( SQL.GetByID, Connection ) )
            {
                cmd.Parameters.AddWithValue( "@Username", userName );

                using( var reader = cmd.ExecuteReader() )
                {
                    while( reader.Read() )
                    {
                        user = new User
                        {
                            ID = Convert.ToInt32( reader[ "ID" ] ),
                            Type = Convert.ToInt32( reader[ "Type" ].ToString() ).ToEnum( UserType.BasicUser ),
                            UserName = reader[ "Username" ].ToString(),
                            PasswordHash = reader[ "PasswordHash" ].ToString()
                        };
                    }
                }
            }
            Connection.Close();

            #region compare database hash to computed password hash

            if( user != null && user.PasswordHash != ComputeHash(password) )
            { 
                // incorrect password, return null
                user = null;
            }

            #endregion

            return user;
        }

        string ComputeHash(string input)
        {
            var sha1 = new SHA1CryptoServiceProvider();
            var salted = string.Format( "sodium: {0}", input );
            var saltedBytes = Encoding.GetEncoding( "ISO-8859-1" ).GetBytes( salted );
            var hashedBytes = sha1.ComputeHash( saltedBytes );
            return BitConverter.ToString(hashedBytes).Replace("-", string.Empty);
        }

        #endregion
    }
}
