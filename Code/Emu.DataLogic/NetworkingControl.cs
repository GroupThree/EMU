using Emu.Common;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Emu.DataLogic
{
    public class NetworkingControl : INetworkingManager
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

        public NetworkingControl()
        {
            Connection = new MySqlConnection( "connection_string" ); 
        }

        #endregion
        #region Methods

        public List<NetworkAddress> Get()
        {
            var results = new List<NetworkAddress>();
            
            return results;
        }

        public NetworkAddress Get( int id )
        {
            #region Validate Arguments

            #endregion

            NetworkAddress result = null;

            return result;
        }

        public void Create( NetworkAddress address )
        {
            #region Validate Arguments

            #endregion

        }

        public void Update( NetworkAddress address )
        {
            #region Validate Arguments

            #endregion

        }

        public void CreateRelationship( NetworkAddress address, Equipment equipment )
        {
            #region Validate Arguments

            #endregion
        }

        #endregion
    }
}
