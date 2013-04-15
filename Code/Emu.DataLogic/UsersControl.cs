using Emu.Common;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
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
            public const string GetAll = "select * from asdfasdfa";
            public const string GetByBarcode = "select * from asdfasdf where";
            public const string Create = "insert into asdfasdf() values ()";
            public const string Update = "update asdfasdf set  fdsadfds where  fdsawer";
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
            
            return result;
        }

        public User Get( int id )
        {
            #region Validate Arguments
            
            #endregion

            User result = null;
            
            return result;
        }

        public void Create( User user )
        {
            #region Validate Arguments
            
            #endregion

        }

        public void Update( User user )
        {
            #region Validate Arguments

            #endregion

        }

        public User Authenticate( string userName, string password )
        {
            #region Validate Arguments

            #endregion

            User result = null;

            return result;
        }

        #endregion
    }
}
