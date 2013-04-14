using Emu.Common;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Emu.DataLogic
{
    public class EquipmentManager : IEquipmentManager
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

        public EquipmentManager()
        {
            Connection = new MySqlConnection( "connection_string" ); 
        }

        #endregion
        #region Methods

        public List<Equipment> GetEquipment()
        {
            var results = new List<Equipment>();

            using( var cmd = new MySqlCommand( SQL.GetAll, Connection ) )
            {
                using( var reader = cmd.ExecuteReader() )
                {
                    while( reader.Read() )
                    {
                        // populate an equipment record
                    }
                }
            }

            return results;
        }

        public Equipment GetEquipment( int barcode )
        {
            #region Validate Arguments

            if ( barcode.Positive() == false )
            {
                throw new ArgumentException( "Barcode argument must be a positive integer.", "barcode" );
            }

            #endregion

            Equipment result = null;

            using( var cmd = new MySqlCommand( SQL.GetByBarcode, Connection ) )
            {
                cmd.Parameters.AddWithValue( "@BarCode", barcode );

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

                        // populate the relationships of an Equipment record too
                    }
                }
            }

            return result;
        }

        public void CreateEquipment( Equipment equipment )
        {
            #region Validate Arguments
            
            if ( equipment == null )
            {
                throw new ArgumentException( "Equipment argument must not be null.", "equipment" );
            }
            if ( equipment.BarCode.Positive() == false )
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

        public void UpdateEquipment( Equipment equipment )
        {
            #region Validate Arguments

            if ( equipment == null )
            {
                throw new ArgumentException( "Equipment argument must not be null.", "equipment" );
            }
            if ( equipment.BarCode.Positive() == false )
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
