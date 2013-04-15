using Emu.Common;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Emu.DataLogic
{
    public class SoftwareControl : ISoftwareManager
    {
        #region Properties

        MySqlConnection Connection { get; set; }

        struct SQL
        {
            public const string GetAll = "select * from Software";
            public const string GetByBarcode = "select * from Software where BarCode = @BarCode";
            public const string Create = "insert into Software(BarCode, SerialNumber, Description) values (@BarCode, @SerialNumber, @Description)";
            public const string Update = "update Software set SerialNumber = @SerialNumber, Description = @Description where BarCode = @BarCode";
        }

        #endregion
        #region Constructor

        public SoftwareControl()
        {
            Connection = new MySqlConnection( "connection_string" );
        }

        #endregion
        #region Methods

        public List<Software> Get()
        {
            var results = new List<Software>();

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

        public Software Get( int barcode )
        {
            #region Validate Arguments

            #endregion

            Software result = null;

            using( var cmd = new MySqlCommand( SQL.GetByBarcode, Connection ) )
            {
                cmd.Parameters.AddWithValue( "@BarCode", barcode );

                using( var reader = cmd.ExecuteReader() )
                {
                    while( reader.Read() )
                    {
                        result = new Software
                        {
                            BarCode = Convert.ToInt32( reader[ "BarCode" ] ),
                            SerialNumber = reader[ "SerialNumber" ].ToString(),
                            Description = reader[ "Description" ].ToString()
                        };

                        // populate the relationships of an Equipment record too
                    }
                }
            }

            return result;
        }

        public void Create( Software software )
        {
            #region Validate Arguments

            #endregion

            using( var cmd = new MySqlCommand( SQL.Create, Connection ) )
            {
                cmd.Parameters.AddWithValue( "@BarCode", software.BarCode );
                cmd.Parameters.AddWithValue( "@SerialNumber", software.SerialNumber );
                cmd.Parameters.AddWithValue( "@Description", software.Description );

                // run the update statement
                cmd.ExecuteNonQuery();
            }

        }

        public void Update( Software software )
        {
            #region Validate Arguments

            #endregion

            using( var cmd = new MySqlCommand( SQL.Update, Connection ) )
            {
                cmd.Parameters.AddWithValue( "@BarCode", software.BarCode );
                cmd.Parameters.AddWithValue( "@SerialNumber", software.SerialNumber );
                cmd.Parameters.AddWithValue( "@Description", software.Description );

                // run the update statement
                cmd.ExecuteNonQuery();
            }

        }

        #endregion
    }
}
