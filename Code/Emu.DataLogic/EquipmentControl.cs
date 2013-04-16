using Emu.Common;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Emu.DataLogic
{
    public class EquipmentControl : IEquipmentManager
    {
        #region Properties

        MySqlConnection Connection { get; set; }

        struct SQL
        {
            public const string GetAll = "select * from Equipment";
            public const string GetByBarcode = "select * from Equipment where BarCode = @BarCode";
            public const string Create = "insert into Equipment(BarCode, Description, WarrantyExpiration, Location) values (@BarCode, @Description, @WarrantyExpiration, @Location)";
            public const string Update = "update Equipment set Description = @Description, WarrantyExpiration = @WarrantyExpiration, Location = @Location where BarCode = @BarCode";
        }

        #endregion
        #region Constructor

        public EquipmentControl()
        {
            Connection = new MySqlConnection( "connection_string" ); 
        }

        #endregion
        #region Methods        

        public List<Equipment> Get()
        {
            var results = new List<Equipment>();

            using( var cmd = new MySqlCommand( SQL.GetAll, Connection ) )
            {
                using( var reader = cmd.ExecuteReader() )
                {
                    while( reader.Read() )
                    {
                        results.Add( new Equipment
                        {
                            BarCode = Convert.ToInt32( reader[ "BarCode" ].ToString() ),
                            Description = reader[ "Description" ].ToString(),
                            Location = reader[ "Location" ].ToString(),
                            WarrantyExpiration = DateTime.Parse( reader[ "WarrantyExpiration" ].ToString() )
                        } );
                    }
                }
            }

            return results;
        }

        public Equipment Get( int barCode )
        {
            #region Validate Arguments

            if ( barCode.IsPositive() == false )
            {
                throw new ArgumentException( "Barcode argument must be a positive integer.", "barcode" );
            }

            #endregion

            Equipment result = null;

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
                            Description = reader["Description"].ToString(),
                            Location = reader["Location"].ToString(),
                            WarrantyExpiration = DateTime.Parse(reader["WarrantyExpiration"].ToString())
                        };

                    }
                }
            }

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
            if ( equipment.BarCode.IsPositive() == false )
            {
                throw new ArgumentException( "Equipment barcode must be a positive integer.", "barcode" );
            }

            #endregion

            using( var cmd = new MySqlCommand( SQL.Create, Connection ) )
            {
                cmd.Parameters.AddWithValue( "@BarCode", equipment.BarCode );
                cmd.Parameters.AddWithValue( "@Description", equipment.Description );
                cmd.Parameters.AddWithValue( "@Location", equipment.Location );
                cmd.Parameters.AddWithValue( "@WarrantyExpiration", equipment.WarrantyExpiration );

                // run the update statement
                cmd.ExecuteNonQuery();
            }
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

            using( var cmd = new MySqlCommand( SQL.Update, Connection ) )
            {
                cmd.Parameters.AddWithValue( "@BarCode", equipment.BarCode );
                cmd.Parameters.AddWithValue( "@Description", equipment.Description );
                cmd.Parameters.AddWithValue( "@Location", equipment.Location );
                cmd.Parameters.AddWithValue( "@WarrantyExpiration", equipment.WarrantyExpiration );

                // run the update statement
                cmd.ExecuteNonQuery();
            }
        }

        public void CreateRelationship( Equipment equipment, User user ) 
        {
            #region Validate Arguments

            #endregion
        }

        #endregion
    }
}
