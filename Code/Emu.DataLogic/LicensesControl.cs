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
    public class LicensesControl : ILicensesManager
    {
        #region Properties
        
        MySqlConnection Connection { get; set; }

        struct SQL
        {
            public const string GetAll = @"SELECT
                                                    ID,
                                                    EquipmentBarCode,
                                                    SoftwareBarCode,
                                                    LicenseKey,
                                                    ExpirationDate,
                                                    BarCode,
                                                    SerialNumber,
                                                    Description
                                            FROM 
                                                    License
                                            LEFT JOIN
                                                    Software
                                            ON
                                                    License.SoftwareBarCode = Software.BarCode";
            
            public const string GetByID = @"SELECT
                                                    ID,
                                                    EquipmentBarCode,
                                                    SoftwareBarCode,
                                                    LicenseKey,
                                                    ExpirationDate,
                                                    BarCode,
                                                    SerialNumber,
                                                    Description
                                            FROM 
                                                    License
                                            LEFT JOIN
                                                    Software
                                            ON
                                                    License.SoftwareBarCode = Software.BarCode
                                            WHERE
                                                    ID = @ID";

            public const string Create = @" INSERT INTO License
                                            (
                                                    ID,
                                                    EquipmentBarCode,
                                                    SoftwareBarCode,
                                                    LicenseKey,
                                                    ExpirationDate
                                            )
                                            VALUES
                                            (
                                                    @ID,
                                                    @EquipmentBarCode,
                                                    @SoftwareBarCode,
                                                    @LicenseKey,
                                                    @ExpirationDate
                                            )";

            public const string Update = @" UPDATE
                                                    License
                                            SET
                                                    EquipmentBarCode = @EquipmentBarCode,
                                                    SoftwareBarCode = @SoftwareBarCode,
                                                    LicenseKey = @LicenseKey,
                                                    ExpirationDate = @ExpirationDate
                                            WHERE
                                                    ID = @ID";

        }

        #endregion
        #region Constructor

        public LicensesControl()
        {
            Connection = new MySqlConnection( Settings.Default.ConnectionString ); 
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
                        results.Add( new License
                        {
                            ID = Convert.ToInt32( reader[ "ID" ].ToString() ),
                            LicenseKey = reader[ "LicenseKey" ].ToString(),
                            ExpirationDate = DateTime.Parse( reader[ "ExpirationDate" ].ToString() ),
                            Software = new Software
                            {
                                BarCode = Convert.ToInt32( reader[ "BarCode" ].ToString() ),
                                Description = reader[ "Description" ].ToString(),
                                SerialNumber = reader[ "SerialNumber" ].ToString()
                            }
                        } );
                    }
                }
            }
            
            return results;
        }

        public License Get( int id )
        {
            License result = null;

            using( var cmd = new MySqlCommand( SQL.GetByID, Connection ) )
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
                throw new ArgumentException( "License argument must not be null.", "License" );
            }

            if( license.ID.IsPositive() == false )
            {
                throw new ArgumentException( "The License ID must be positive.", "License ID" );
            }

            if( license.Software == null )
            {
                throw new ArgumentException( "The Software associated with the license must not be null.", "software" );
            }

            if( license.Software.BarCode.IsPositive() == false )
            {
                throw new ArgumentException( "The BarCode associated with the Software must be positive.", "Software BarCode" );
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

            if( license == null )
            {
                throw new ArgumentException( "License argument must not be null.", "License" );
            }

            if( license.ID.IsPositive() == false )
            {
                throw new ArgumentException( "The License ID must be positive.", "License ID" );
            }

            if( license.Software == null )
            {
                throw new ArgumentException( "The Software associated with the license must not be null.", "software" );
            }

            if( license.Software.BarCode.IsPositive() == false )
            {
                throw new ArgumentException( "The BarCode associated with the Software must be positive.", "Software BarCode" );
            }

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

        #endregion
    }
}
