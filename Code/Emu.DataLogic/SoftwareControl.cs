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
    public class SoftwareControl : ISoftwareControl
    {
        #region Properties

        MySqlConnection Connection { get; set; }

        struct SQL
        {
            public const string Get = "select * from Software";
            public const string GetByBarcode = "select * from Software where BarCode = @BarCode";
            public const string Create = "insert into Software(BarCode, SerialNumber, Description) values (@BarCode, @SerialNumber, @Description)";
            public const string Update = "update Software set SerialNumber = @SerialNumber, Description = @Description where BarCode = @BarCode";
        }

        #endregion
        #region Constructor

        public SoftwareControl()
        {
            Connection = new MySqlConnection( Settings.Default.ConnectionString ); 
        }

        #endregion
        #region Methods

        public List<Software> Get()
        {
            var results = new List<Software>();
            
            Connection.Open();
            using( var cmd = new MySqlCommand( SQL.Get, Connection ) )
            {
                using( var reader = cmd.ExecuteReader() )
                {
                    while( reader.Read() )
                    {
                        results.Add( new Software
                        {
                            BarCode = Convert.ToInt32(reader["BarCode"].ToString()),
                            Description = reader["Description"].ToString(),
                            SerialNumber = reader["SerialNumber"].ToString()
                        } );
                    }
                }
            }
            Connection.Close();

            return results;
        }

        public Software Get( int barCode )
        {
            #region Validate Arguments

            if( barCode.IsPositive() == false )
            {
                throw new ArgumentException( "Barcode argument must be a positive integer.", "barcode" );
            }

            #endregion

            Software result = null;

            Connection.Open();
            using( var cmd = new MySqlCommand( SQL.GetByBarcode, Connection ) )
            {
                cmd.Parameters.AddWithValue( "@BarCode", barCode );

                using( var reader = cmd.ExecuteReader() )
                {
                    while( reader.Read() )
                    {
                        result = new Software
                        {
                            BarCode = Convert.ToInt32( reader[ "BarCode" ].ToString() ),
                            SerialNumber = reader[ "SerialNumber" ].ToString(),
                            Description = reader[ "Description" ].ToString()
                        };
                    }
                }
            }
            Connection.Close();

            return result;
        }

        public void Create( Software software )
        {
            #region Validate Arguments

            if( software == null )
            {
                throw new ArgumentException( "Software argument must not be null.", "software" );
            }
            
            if( software.BarCode.IsPositive() == false )
            {
                throw new ArgumentException( "Software barcode must be a positive integer.", "barCode" );
            }

            #endregion

            Connection.Open();
            using( var cmd = new MySqlCommand( SQL.Create, Connection ) )
            {
                cmd.Parameters.AddWithValue( "@BarCode", software.BarCode );
                cmd.Parameters.AddWithValue( "@SerialNumber", software.SerialNumber );
                cmd.Parameters.AddWithValue( "@Description", software.Description );

                // run the update statement
                cmd.ExecuteNonQuery();
            }
            Connection.Close();
        }

        public void Update( Software software )
        {
            #region Validate Arguments

            if( software == null )
            {
                throw new ArgumentException( "Software argument must not be null.", "software" );
            }

            if( software.BarCode.IsPositive() == false )
            {
                throw new ArgumentException( "Software barcode must be a positive integer.", "barCode" );
            }

            #endregion

            Connection.Open();
            using( var cmd = new MySqlCommand( SQL.Update, Connection ) )
            {
                cmd.Parameters.AddWithValue( "@BarCode", software.BarCode );
                cmd.Parameters.AddWithValue( "@SerialNumber", software.SerialNumber );
                cmd.Parameters.AddWithValue( "@Description", software.Description );

                // run the update statement
                cmd.ExecuteNonQuery();
            }
            Connection.Close();
        }

        #endregion
    }
}
