using Emu.Common;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Emu.DataLogic
{
    public class LicensesControl : ILicensesManager
    {
        #region Properties
        
        MySqlConnection Connection { get; set; }

        struct SQL
        {
            public const string GetAll = "select * from License inner join Software on SoftwareBarCode = BarCode";
            public const string GetByBarcode = "select * from License where ID = @ID";
            public const string Create = "insert into License(SoftwareBarCode, LicenseKey, ExpirationDate) values (@SoftwareBarCode, @LicenseKey, @ExpirationDate)";
            public const string Update = "update License set SoftwareBarCode = @SoftwareBarCode, LicenseKey = @LicenseKey, ExpirationDate = @ExpirationDate where ID = @ID";
        }

        #endregion
        #region Constructor

        public LicensesControl()
        {
            Connection = new MySqlConnection( "connection_string" ); 
        }

        #endregion
        #region Methods

        public List<License> Get()
        {
            var results = new List<License>();

            using( var cmd = new MySqlCommand( SQL.GetAll, Connection ) )
            {
                using( var reader = cmd.ExecuteReader() )
                {
                    while( reader.Read() )
                    {
                        // populate a License record
                        var license = new License
                        {
                            ID = Convert.ToInt32( reader[ "ID" ].ToString() ),
                            LicenseKey = reader[ "LicenseKey" ].ToString(),
                            ExpirationDate = DateTime.Parse( reader[ "ExpirationDate" ].ToString() ),
                            Software = new Software
                            {
                                BarCode = Convert.ToInt32(reader["BarCode"].ToString()),
                                Description = reader["Description"].ToString(),
                                SerialNumber = reader["SerialNumber"].ToString()
                            }
                        };

                        // need to add the software the license is for

                        results.Add( license );
                    }
                }
            }
            
            return results;
        }

        public License Get( int id )
        {
            License result = null;

            using( var cmd = new MySqlCommand( SQL.GetByBarcode, Connection ) )
            {
                cmd.Parameters.AddWithValue( "@ID", id );

                using( var reader = cmd.ExecuteReader() )
                {
                    while( reader.Read() )
                    {
                        result = new License
                        {
                            ID = Convert.ToInt32( reader[ "ID" ].ToString() ),
                            LicenseKey = reader[ "LicenseKey" ].ToString(),
                            ExpirationDate = DateTime.Parse( reader[ "ExpirationDate" ].ToString()),
                            Software = new Software
                            {
                                BarCode = Convert.ToInt32(reader["BarCode"].ToString()),
                                Description = reader["Description"].ToString(),
                                SerialNumber = reader["SerialNumber"].ToString()
                            }
                        };
                        
                    }
                }
            }

            return result;
        }

        public void Create( License license )
        {
            #region Validate Arguments

            if( license == null )
            {
                throw new ArgumentException( "License argument must not be null", "License" );
            }

            if( license.Software == null )
            {
                throw new ArgumentException( "The Software associated with the license must not be null", "Software" );
            }

            if( license.ID.IsPositive() == false )
            {
                throw new ArgumentException( "The License ID must be positive", "License ID" );
            }

            if( license.Software.BarCode.IsPositive() == false )
            {
                throw new ArgumentException( "The BarCode associated with the Software must be positive", "Software BarCode" );
            }

            #endregion

            using( var cmd = new MySqlCommand( SQL.Create, Connection ) )
            {
                cmd.Parameters.AddWithValue( "@ID", license.ID );
                cmd.Parameters.AddWithValue( "@SoftwareBarCode", license.Software.BarCode );
                cmd.Parameters.AddWithValue( "@LicenseKey", license.LicenseKey );
                cmd.Parameters.AddWithValue( "@ExpirationDate", license.ExpirationDate);

                // run the update statement
                cmd.ExecuteNonQuery();
            }
        }

        public void Update( License license )
        {
            #region Validate Arguments

            Validate( license );

            #endregion

            using( var cmd = new MySqlCommand( SQL.Update, Connection ) )
            {
                cmd.Parameters.AddWithValue( "@ID", license.ID );
                cmd.Parameters.AddWithValue( "@SoftwareBarCode", license.Software.BarCode );
                cmd.Parameters.AddWithValue( "@LicenseKey", license.LicenseKey );
                cmd.Parameters.AddWithValue( "@ExpirationDate", license.ExpirationDate );

                // run the update statement
                cmd.ExecuteNonQuery();
            }
        }

        

        public void CreateRelationship( License license, Equipment equipment )
        {
            #region Validate Arguments

            #endregion
        }

        private static void Validate( License license )
        {
            if( license == null )
            {
                throw new ArgumentException( "License argument must not be null", "License" );
            }

            if( license.Software == null )
            {
                throw new ArgumentException( "The Software associated with the license must not be null", "Software" );
            }

            if( license.ID.IsPositive() == false )
            {
                throw new ArgumentException( "The License ID must be positive", "License ID" );
            }

            if( license.Software.BarCode.IsPositive() == false )
            {
                throw new ArgumentException( "The BarCode associated with the Software must be positive", "Software BarCode" );
            }
        }

        #endregion
    }
}
