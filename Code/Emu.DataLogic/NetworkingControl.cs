using Emu.Common;
using Emu.DataLogic.Properties;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Emu.DataLogic
{
    public class NetworkingControl : INetworkingControl
    {
        #region Properties
        
        MySqlConnection Connection { get; set; }

        struct SQL
        {
            public const string Get = @"SELECT
		                                        ID,
		                                        IP,
		                                        EquipmentBarCode,
		                                        SerialNumber,
		                                        Description,
		                                        Location
                                        FROM 
		                                        NetworkAddress
                                        LEFT JOIN 
		                                        Equipment
                                        ON
		                                        EquipmentBarCode = BarCode";

            public const string GetByID = @"SELECT
		                                            ID,
		                                            IP,
		                                            EquipmentBarCode,
		                                            SerialNumber,
		                                            Description,
		                                            Location
                                            FROM 
                                                    NETWORKADDRESS
                                            LEFT JOIN 
		                                            Equipment
                                            ON
		                                            EquipmentBarCode = BarCode
                                            WHERE 
		                                            ID = @ID";

            public const string GetAvailable = @"SELECT
                                                        ID,
                                                        IP,
                                                        Description,
                                                        Location
                                                 WHERE
                                                        EquipmentBarCode = 1"; // (not used yet)

            public const string Create = @"INSERT INTO NETWORKADDRESS
                                                    (
                                                    IP,
                                                    EquipmentBarCode 
                                                    )
                                            VALUES 
                                                    (
                                                    @IP, 
                                                    @EquipmentBarCode
                                                    )";

            public const string Update =  @"UPDATE 
                                                    NETWORKADDRESS 
                                            SET
		                                            IP = @IP,
		                                            EquipmentBarCode = @EquipmentBarCode
                                            WHERE
		                                            ID = @ID";
        }

        #endregion
        #region Constructor

        public NetworkingControl()
        {
            Connection = new MySqlConnection( Settings.Default.ConnectionString ); 
        }

        #endregion
        #region Methods

        public List<NetworkAddress> Get()
        {
            var results = new List<NetworkAddress>();

            if( Connection.State == System.Data.ConnectionState.Closed ) { Connection.Open(); }

            using( var cmd = new MySqlCommand(SQL.Get, Connection) )
            {
                using( var reader = cmd.ExecuteReader() )
                {
                    while( reader.Read() )
                    {
                        results.Add(new NetworkAddress
                        {
                            ID = Convert.ToInt32(reader["ID"].ToString()),
                            IP = IPAddress.Parse(reader["IP"].ToString()),
                            InstalledOn = new Equipment
                            {
                                BarCode = Convert.ToInt32(reader["EquipmentBarCode"].ToString()),
                                Description = reader["Description"].ToString(),
                                Location = reader["Location"].ToString()
                            }
                        });
                    }
                }
            }

            Connection.Close();

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

            if( Connection.State == System.Data.ConnectionState.Closed ) { Connection.Open(); }
            using( var cmd = new MySqlCommand( SQL.GetByID, Connection ) )
            {
                cmd.Parameters.AddWithValue( "@ID", id );
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
                                BarCode = Convert.ToInt32(reader["EquipmentBarCode"].ToString()),
                                Description = reader["Description"].ToString(),
                                Location = reader["Location"].ToString()
                            }
                        };
                    }
                }
            }
            Connection.Close();

            return result;
        }

        public void Create( NetworkAddress address)
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

            if( Connection.State == System.Data.ConnectionState.Closed ) { Connection.Open(); }

            using( var cmd = new MySqlCommand( SQL.Create, Connection ) )
            {
                cmd.Parameters.AddWithValue( "@IP", address.IP );
                cmd.Parameters.AddWithValue( "@EquipmentBarCode",  1 /* system placeholder */);
                
                cmd.ExecuteNonQuery();
            }

            Connection.Close();
        }

        public void Update( NetworkAddress address )
        {
            #region Validate Arguments

            #endregion

            if( Connection.State == System.Data.ConnectionState.Closed ) { Connection.Open(); }

            using( var cmd = new MySqlCommand( SQL.Update, Connection ) )
            {
                cmd.Parameters.AddWithValue( "@ID", address.ID );
                cmd.Parameters.AddWithValue( "@IP", address.IP );
                cmd.Parameters.AddWithValue( "@EquipmentBarCode", address.InstalledOn.BarCode );

                cmd.ExecuteNonQuery();
            }

            Connection.Close();
        }
        
        #endregion
    }
}
