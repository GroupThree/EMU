using Emu.Common;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Emu.DataLogic
{
    public class UsersControl : IUsersManager
    {
        #region Properties
        
        MySqlConnection Connection { get; set; }

        struct SQL
        {
            public const string GetAll  = @"SELECT
                                                    ID,
                                                    Type,
                                                    Username,
                                                    Password 
                                            FROM 
                                                    EmuUser";
            
            public const string GetByID = @"SELECT 
                                                    ID,
                                                    Type,
                                                    Username,
                                                    Password 
                                            FROM 
                                                    EmuUser 
                                            WHERE 
                                                    ID = @ID";
            
            public const string GetByUsername = @"  SELECT
                                                            ID,
                                                            Type,
                                                            Username,
                                                            Password 
                                                    FROM 
                                                            EmuUser 
                                                    WHERE 
                                                            Username = @Username";
            
            public const string Create  = @"INSERT INTO EmuUser 
                                            (
                                                    Type,
                                                    Username,
                                                    Password
                                            ) 
                                            VALUES 
                                            (
                                                    @Type, 
                                                    @Username, 
                                                    @Password
                                            )";
            
            public const string Update  = @"UPDATE 
                                                    EmuUser 
                                            SET 
                                                    Type = @Type, 
                                                    Username = @Username, 
                                                    Password = @Password 
                                            WHERE 
                                                    ID = @ID";
        }

        #endregion
        #region Constructor

        public UsersControl()
        {
            Connection = new MySqlConnection( "connection_string" ); 
        }

        #endregion
        #region Methods
        
        public List<User> Get()
        {
            var result = new List<User>();

            using (var cmd = new MySqlCommand(SQL.GetAll, Connection))
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
            
            return result;
        }

        public void Create( User user )
        {
            #region Validate Arguments

            // TODO : validation

            #endregion

            using (var cmd = new MySqlCommand(SQL.Create, Connection))
            {
                cmd.Parameters.AddWithValue("@ID", user.ID);
                cmd.Parameters.AddWithValue("@Type", user.Type);
                cmd.Parameters.AddWithValue("@Username", user.UserName);
                cmd.Parameters.AddWithValue("@Password", user.PasswordHash);

                // run the update statement
                cmd.ExecuteNonQuery();
            }

        }

        public void Update( User user )
        {
            #region Validate Arguments

            #endregion

            using (var cmd = new MySqlCommand(SQL.Update, Connection))
            {
                cmd.Parameters.AddWithValue("@ID", user.ID);
                cmd.Parameters.AddWithValue("@Type", user.Type);
                cmd.Parameters.AddWithValue("@Username", user.UserName);
                cmd.Parameters.AddWithValue("@Password", user.PasswordHash);

                // run the update statement
                cmd.ExecuteNonQuery();
            }

        }

        public User Authenticate( string userName, string password )
        {
            #region Validate Arguments

            #endregion

            User user = null;

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
