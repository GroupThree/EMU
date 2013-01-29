using Emu.Common;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Emu.Data
{
    public class ExampleUserRepository
    {
        /// <summary>
        /// Class containing all SQL queries for the ExampleUserRepository
        /// </summary>
        class SQL
        {
            public const string FindExampleUserQuery = @"SELECT UserID, UserName, Active FROM ExampleUsers WHERE UserID = @UserID;";
            public const string AllActiveExampleUsersQuery = @"SELECT UserID, UserName, Active FROM ExampleUsers WHERE Active = 1;";
        }

        #region properties

        /// <summary>
        /// This is the object that represents our connection to the MySql database
        /// </summary>
        MySqlConnection DB { get; set; }

        #endregion
        #region constructor

        public ExampleUserRepository()
        {
            // Creating the connection to the database, we may want to load this from a config file and user encryption for security
            DB = new MySqlConnection("Server=localhost;Database=EMU;Uid=emuUser;Pwd=emuPassword;");
        }

        #endregion
        #region methods


        /// <summary>
        /// An example to show how queries might 
        /// </summary>
        /// <param name="userID"></param>
        /// <returns></returns>
        public ExampleUser FindUser(Guid userID)
        {
            ExampleUser user = null;

            // we need to create a MySqlCommand that represents our query
            // the using statement releases any resources(ex: transactions) used by the command when it exits this block of code
            using (var cmd = new MySqlCommand(SQL.FindExampleUserQuery, DB))
            {
                // here we add the guid to the query so that it replaces the @UserID parameter(look up parameterized queries on why to use this)
                cmd.Parameters.AddWithValue("@UserID", userID);

                // execute the command and use a reader to get the results
                using (var reader = cmd.ExecuteReader())
                {
                    // Read() allows you to read one record at a time from the results
                    // It returns true when it has moved to a new record, false if there are no more records
                    while (reader.Read())
                    {
                        
                        /*  The syntax below is shorthand for:
                         *  user = new ExampleUser();
                         *  user.UserID = Guid.Parse(reader["UserID"].ToString());
                         *  user.UserName = reader["UserName"].ToString();
                         *  user.Active = Active = reader["Active"].ToString().Equals("1");
                         */

                        user = new ExampleUser
                        {
                            UserID = Guid.Parse(reader["UserID"].ToString()), /* reader["UserID"] is an object representing the users Guid, need to parse the tostring of this object */
                            UserName = reader["UserName"].ToString(),  /* reader["UserName"] is an object representing the username, need to tostring to populate the object */
                            Active = reader["Active"].ToString().Equals("1")  /* not sure this is right for MySQL w/ .Net */
                        };
                    }
                }
            }

            return user;
        }

        public List<ExampleUser> ActiveUsers()
        {
            var activeUsers = new List<ExampleUser>();

            using (var cmd = new MySqlCommand(SQL.AllActiveExampleUsersQuery, DB))
            {
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        // add the user to our list
                        activeUsers.Add(new ExampleUser
                        {
                            UserID = Guid.Parse(reader["UserID"].ToString()),
                            UserName = reader["UserName"].ToString(),  
                            Active = reader["Active"].ToString().Equals("1")
                        });
                    }
                }
            }

            return activeUsers;
        }

        #endregion
    }
}
