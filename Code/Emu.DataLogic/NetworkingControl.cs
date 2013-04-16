using Emu.Common;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
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
            public const string GetByID = "select * from asdfasdf where";
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

            if( id.IsPositive() == false )
            {
                throw new ArgumentException( "The id must be a positive number.", "id" );
            }

            #endregion

            NetworkAddress result = null;

            using( var cmd = new MySqlCommand( SQL.GetByID, Connection ) )
            {
                using( var reader = cmd.ExecuteReader() )
                {
                    while( reader.Read() )
                    {
                        result = new NetworkAddress
                        {
                            ID = Convert.ToInt32( reader[ "ID" ].ToString() ),
                            IP = IPAddress.Parse( reader[ "IP" ].ToString() ),
                            InstalledOn = new Equipment 
                            {
                                BarCode = Convert.ToInt32(reader["BarCode"].ToString()),
                                Description = reader["Description"].ToString(),
                                Location = reader["Location"].ToString(),
                                WarrantyExpiration = DateTime.Parse(reader["WarrantyExpiration"].ToString())
                            }
                        };
                    }
                }
            }

            return result;
        }

        public void Create( NetworkAddress address )
        {
            #region Validate Arguments

            if( address == null )
            {
                throw new ArgumentException( "The Address must not be null", "address" );
            }

            if(address.InstalledOn != null 
                    && address.InstalledOn.BarCode.IsPositive() == false)
            {
                throw new ArgumentException("The barCode of the equipment must be positive.", "barCode");
            }

            #endregion

            using( var cmd = new MySqlCommand( SQL.Create, Connection ) )
            {
                cmd.Parameters.AddWithValue( "@ID", address.ID );
                cmd.Parameters.AddWithValue( "@IP", address.IP );
                cmd.Parameters.AddWithValue( "@InstalledOn",  address.InstalledOn != null ? (object)address.InstalledOn.BarCode : DBNull.Value );
                
                cmd.ExecuteNonQuery();
            }
        }

        public void Update( NetworkAddress address )
        {
            #region Validate Arguments

            #endregion

            using( var cmd = new MySqlCommand( SQL.Update, Connection ) )
            {
                cmd.Parameters.AddWithValue( "@ID", address.ID );
                cmd.Parameters.AddWithValue( "@IP", address.IP );
                cmd.Parameters.AddWithValue( "@InstalledOn", address.InstalledOn != null ? (object)address.InstalledOn.BarCode : DBNull.Value );

                cmd.ExecuteNonQuery();
            }
        }

        public void CreateRelationship( NetworkAddress address, Equipment equipment )
        {
            #region Validate Arguments

            #endregion


        }

        #endregion
    }
}
