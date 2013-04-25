using Emu.Common;
using Emu.DataLogic.Properties;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Emu.DataLogic
{
    public class EquipmentControl : IEquipmentControl
    {
        #region Properties

        MySqlConnection Connection { get; set; }

        struct SQL
        {
            
            public const string Get = @"    SELECT 
                                                        BarCode,
                                                        SerialNumber,
                                                        Description,
                                                        Location,
                                                        WarrantyExpiration,
                                                        UserID,
                                                        Username
                                            FROM
                                                        Equipment
                                            LEFT JOIN
                                                        EmuUser
                                            ON
                                                        EmuUser.ID = Equipment.UserID";

            
            public const string GetByBarcode = @"SELECT
                                                            BarCode,
                                                            SerialNumber,
                                                            Description,
                                                            Location,
                                                            WarrantyExpiration,
                                                            UserID,
                                                            Username
                                                 FROM
                                                            Equipment
                                                 LEFT JOIN
                                                            EmuUser
                                                 ON
                                                            EmuUser.ID = Equipment.UserID
                                                 WHERE
                                                            BarCode = @BarCode";
            
            public const string Create = @" INSERT INTO Equipment 
                                            (
                                                BarCode,
                                                SerialNumber,
                                                UserID,
                                                Description,
                                                Location,
                                                WarrantyExpiration
                                            ) 
                                            VALUES
                                            (
                                                @BarCode,
                                                @SerialNumber,
                                                @UserID,
                                                @Description,
                                                @Location,
                                                @WarrantyExpiration
                                            )";

            public const string Update = @" UPDATE
                                                    Equipment 
                                            SET
                                                    SerialNumber = @SerialNumber,
                                                    UserID = @UserID,
                                                    Description = @Description,
                                                    Location = @Location,
                                                    WarrantyExpiration = @WarrantyExpiration
                                            WHERE
                                                    BarCode = @BarCode";
        }

        #endregion
        #region Constructor

        public EquipmentControl()
        {
            Connection = new MySqlConnection( Settings.Default.ConnectionString );
        }

        #endregion
        #region Methods

        public List<Equipment> Get()
        {
            var results = new List<Equipment>();

            if( Connection.State == System.Data.ConnectionState.Closed ) { if( Connection.State == System.Data.ConnectionState.Closed ) { Connection.Open(); } }
            
            
            using( var cmd = new MySqlCommand( SQL.Get, Connection ) )
            {
                using( var reader = cmd.ExecuteReader() )
                {
                    while( reader.Read() )
                    {
                        results.Add( new Equipment
                        {
                            BarCode = int.Parse( reader[ "BarCode" ].ToString() ),
                            SerialNumber = reader[ "SerialNumber" ].ToString(),
                            Description = reader[ "Description" ].ToString(),
                            Location = reader[ "Location" ].ToString(),
                            WarrantyExpiration = DateTime.Parse( reader[ "WarrantyExpiration" ].ToString() ),
                            UsedBy = new User
                            {
                                ID = int.Parse(reader["UserID"].ToString()),
                                UserName = reader["Username"].ToString()
                            }
                        } );
                    }
                }
            }
            Connection.Close();

            return results;
        }

        public Equipment Get( int barCode )
        {
            Equipment result = null;

            if( Connection.State == System.Data.ConnectionState.Closed ) { Connection.Open(); }

            using( var cmd = new MySqlCommand( SQL.GetByBarcode, Connection ) )
            {
                cmd.Parameters.AddWithValue( "@BarCode", barCode );

                using( var reader = cmd.ExecuteReader() )
                {
                    while( reader.Read() )
                    {
                        result = new Equipment 
                        {
                            BarCode = Convert.ToInt32(reader["BarCode"]),
                            SerialNumber = reader[ "SerialNumber" ].ToString(),
                            Description = reader["Description"].ToString(),
                            Location = reader["Location"].ToString(),
                            WarrantyExpiration = DateTime.Parse(reader["WarrantyExpiration"].ToString()),
                            UsedBy = new User
                            {
                                ID = int.Parse( reader[ "UserID" ].ToString() ),
                                UserName = reader[ "Username" ].ToString()
                            }
                        };

                    }
                }
            }

            Connection.Close();

            // need to load all related lists for Equipment

            return result;
        }

        public void Create( Equipment equipment )
        {
            #region Validate Arguments
            
            if ( equipment == null )
            {
                throw new ArgumentException( "Equipment argument must not be null.", "equipment" );
            }

            #endregion

            if( Connection.State == System.Data.ConnectionState.Closed ) { Connection.Open(); }

            using( var cmd = new MySqlCommand( SQL.Create, Connection ) )
            {
                cmd.Parameters.AddWithValue("@BarCode", equipment.BarCode);
                cmd.Parameters.AddWithValue( "@SerialNumber", equipment.SerialNumber );
                cmd.Parameters.AddWithValue( "@Description", equipment.Description );
                cmd.Parameters.AddWithValue( "@UserID", 1 /* system placeholder */);
                cmd.Parameters.AddWithValue( "@Location", equipment.Location );
                cmd.Parameters.AddWithValue( "@WarrantyExpiration", equipment.WarrantyExpiration );

                // run the update statement
                cmd.ExecuteNonQuery();
            }

            Connection.Close();
        }

        public void Update( Equipment equipment )
        {
            #region Validate Arguments

            if ( equipment == null )
            {
                throw new ArgumentException( "Equipment argument must not be null.", "equipment" );
            }
            if ( equipment.BarCode.IsPositive() == false )
            {
                throw new ArgumentException( "Equipment barcode must be a positive integer.", "barcode" );
            }

            #endregion

            if( Connection.State == System.Data.ConnectionState.Closed ) { Connection.Open(); }

            using( var cmd = new MySqlCommand( SQL.Update, Connection ) )
            {
                cmd.Parameters.AddWithValue( "@BarCode", equipment.BarCode );
                cmd.Parameters.AddWithValue( "@SerialNumber", equipment.SerialNumber );
                cmd.Parameters.AddWithValue( "@Description", equipment.Description );
                cmd.Parameters.AddWithValue( "@UserID", equipment.UsedBy.ID);
                cmd.Parameters.AddWithValue( "@Location", equipment.Location );
                cmd.Parameters.AddWithValue( "@WarrantyExpiration", equipment.WarrantyExpiration );

                // run the update statement
                cmd.ExecuteNonQuery();
            }

            Connection.Close();
        }

        #endregion
    }
}
