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
    public class MaintenanceControl : IMaintenanceManager
    {
        #region Properties
        
        MySqlConnection Connection { get; set; }

        struct SQL
        {
            public const string GetAll = @"     SELECT
                                                            Ticket.ID AS 'TicketID',
                                                            Ticket.Type AS 'TicketType',
                                                            Ticket.Description AS 'TicketDescription',
                                                            Ticket.DateCreated AS 'TicketDateCreated',
                                                            Ticket.DateClosed AS 'TicketDateClosed',
                                                            Equipment.BarCode AS 'EquipmentBarCode',
                                                            Equipment.SerialNumber AS 'EquipmentSerialNumber',
                                                            Equipment.Description AS 'EquipmentDescription',
                                                            Equipment.Location AS 'EquipmentLocation',
                                                            Equipment.WarrantyExpiration AS 'EquipmentWarrantyExpiration',
                                                            License.ID AS 'LicenseID',
                                                            License.LicenseKey AS 'LicenseKey',
                                                            License.ExpirationDate AS 'LicenseExpirationDate',
                                                            Software.BarCode AS 'SoftwareBarCode',
                                                            Software.SerialNumber AS 'SerialNumber',
                                                            Software.Description AS 'SoftwareDescription'
                                                FROM 
                                                            Ticket
                                                LEFT JOIN
                                                            EmuUser ON EmuUser.ID = Ticket.UserID
                                                LEFT JOIN 
                                                            Equipment ON Equipment.BarCode = Ticket.EquipmentBarCode
                                                LEFT JOIN 
                                                            License ON License.ID = Ticket.LicenseID
                                                LEFT JOIN 
                                                            Software ON License.SoftwareBarCode = Software.BarCode";

            public const string GetByID = @"    SELECT
                                                            Ticket.ID AS 'TicketID',
                                                            Ticket.Type AS 'TicketType',
                                                            Ticket.Description AS 'TicketDescription',
                                                            Ticket.DateCreated AS 'TicketDateCreated',
                                                            Ticket.DateClosed AS 'TicketDateClosed',
                                                            Equipment.BarCode AS 'EquipmentBarCode',
                                                            Equipment.SerialNumber AS 'EquipmentSerialNumber',
                                                            Equipment.Description AS 'EquipmentDescription',
                                                            Equipment.Location AS 'EquipmentLocation',
                                                            Equipment.WarrantyExpiration AS 'EquipmentWarrantyExpiration',
                                                            License.ID AS 'LicenseID',
                                                            License.LicenseKey AS 'LicenseKey',
                                                            License.ExpirationDate AS 'LicenseExpirationDate',
                                                            Software.BarCode AS 'SoftwareBarCode',
                                                            Software.SerialNumber AS 'SerialNumber',
                                                            Software.Description AS 'SoftwareDescription'
                                                FROM 
                                                            Ticket
                                                LEFT JOIN
                                                            EmuUser ON EmuUser.ID = Ticket.UserID
                                                LEFT JOIN 
                                                            Equipment ON Equipment.BarCode = Ticket.EquipmentBarCode
                                                LEFT JOIN 
                                                            License ON License.ID = Ticket.LicenseID
                                                LEFT JOIN 
                                                            Software ON License.SoftwareBarCode = Software.BarCode
                                                WHERE 
                                                            Ticket.ID = @ID";

            public const string Create = @" INSERT INTO Ticket
                                            (
                                                    ID,
                                                    UserID,
                                                    EquipmentBarCode,
                                                    LicenseID,
                                                    Type,
                                                    Description,
                                                    DateCreated,
                                                    DateClosed
                                            )
                                            VALUES
                                            (
                                                    @ID,
                                                    @UserID,
                                                    @EquipmentBarCode,
                                                    @LicenseID,
                                                    @Type,
                                                    @Description,
                                                    @DateCreated,
                                                    @DateClosed
                                            )";
            public const string Update = @" UPDATE
                                                    Ticket 
                                            SET
                                                    UserID = @UserID,
                                                    EquipmentBarCode = @EquipmentBarCode,
                                                    LicenseID = @LicenseID,
                                                    Type = @Type,
                                                    Description = @Description,
                                                    DateCreated = @DateCreated,
                                                    DateClosed = @DateClosed
                                            WHERE
                                                    ID = @ID";

        }

        #endregion
        #region Constructor

        public MaintenanceControl()
        {
            Connection = new MySqlConnection( Settings.Default.ConnectionString ); 
        }

        #endregion
        #region Methods
        
        public List<Ticket> Get()
        {
            var results = new List<Ticket>();

            Connection.Open();

            using( var cmd = new MySqlCommand( SQL.Get, Connection ) )
            {
                using( var reader = cmd.ExecuteReader() )
                {
                    while( reader.Read() )
                    {
                        // TODO: finish this loading code
                        results.Add(new Ticket
                        {
                            ID = Convert.ToInt32( reader[ "ID" ].ToString() )
                        });
                    }
                }
            }

            Connection.Close();

            return results;
        }

        public Ticket Get(int id)
        {
            #region Validate Arguments

            if( id.IsPositive() == false )
            {
                throw new ArgumentException( "The ticket id parameter must be positive.", "id" );
            }

            #endregion

            Ticket result = null;

            Connection.Open();

            using( var cmd = new MySqlCommand( SQL.GetByID, Connection ) )
            {
                cmd.Parameters.AddWithValue( "@ID", id );
                using( var reader = cmd.ExecuteReader() )
                {
                    while( reader.Read() )
                    {
                        // TODO: finish this loading
                        result = new Ticket
                        {
                            ID = Convert.ToInt32(reader["ID"].ToString())
                        };
                    }
                }
            }

            Connection.Close();

            return result;
        }

        public void Create( Ticket ticket )
        {
            #region Validate Arguments

            if( ticket == null )
            {
                throw new ArgumentException( "The ticket parameter must not be null", "ticket" );
            }

            if( ticket.ID.IsPositive() == false )
            {
                throw new ArgumentException( "The ticket id parameter must be positive.", "id" );
            }

            if( ticket.Type == TicketType.UserRequested && ticket.Requestor == null)
            {
                throw new ArgumentException( "The requestor must not be null on tickets that are user requested", "Requestor" );
            }

            if( ticket.Type == TicketType.UserRequested && ticket.Requestor.ID.IsPositive() == false )
            {
                throw new ArgumentException( "The requestor's user id must be positive.", "requestor id" );
            }

            if( ticket.Equipment == null )
            {
                throw new ArgumentException( "The equipment cannot be null for a ticket", "equipment" );
            }
            
            if( string.IsNullOrWhiteSpace(ticket.Description) )
            {
                throw new ArgumentException( "The description for the ticket cannot be null or whitespace", "description" );
            }
            
            if( ticket.DateCreated == DateTime.MinValue)
            {
                throw new ArgumentException( "The ticket must have a valid date for the creation date", "date created" );
            }

            #endregion

            using( var cmd = new MySqlCommand( SQL.Create, Connection ) )
            {
                cmd.Parameters.AddWithValue( "@ID", ticket.ID );
                cmd.Parameters.AddWithValue( "@UserID", ticket.Requestor == null ? 1 /* system placeholder */ : ticket.Requestor.ID );
                cmd.Parameters.AddWithValue( "@EquipmentBarCode", ticket.Equipment.BarCode );
                cmd.Parameters.AddWithValue( "@LicenseID", ticket.License == null ? 1 /* system placeholder */ : ticket.License.ID );
                cmd.Parameters.AddWithValue( "@Description", ticket.Description );
                cmd.Parameters.AddWithValue( "@DateCreated", ticket.DateCreated);
                cmd.Parameters.AddWithValue( "@DateClosed", ticket.DateClosed == DateTime.MinValue ? DBNull.Value : (object)ticket.DateClosed);

                // run the update statement
                cmd.ExecuteNonQuery();
            }
        }

        public void Update( Ticket ticket )
        {
            #region Validate Arguments

            if( ticket == null )
            {
                throw new ArgumentException( "The ticket parameter must not be null", "ticket" );
            }

            if( ticket.ID.IsPositive() == false )
            {
                throw new ArgumentException( "The ticket id parameter must be positive.", "id" );
            }

            if( ticket.Type == TicketType.UserRequested && ticket.Requestor == null )
            {
                throw new ArgumentException( "The requestor must not be null on tickets that are user requested", "Requestor" );
            }

            if( ticket.Type == TicketType.UserRequested && ticket.Requestor.ID.IsPositive() == false )
            {
                throw new ArgumentException( "The requestor's user id must be positive.", "requestor id" );
            }

            if( ticket.Equipment == null )
            {
                throw new ArgumentException( "The equipment cannot be null for a ticket", "equipment" );
            }

            if( string.IsNullOrWhiteSpace( ticket.Description ) )
            {
                throw new ArgumentException( "The description for the ticket cannot be null or whitespace", "description" );
            }
            if( ticket.DateCreated == DateTime.MinValue )
            {
                throw new ArgumentException( "The ticket must have a valid date for the creation date", "date created" );
            }

            /* DateClosed can be minval (that's how we know the ticket's still open */

            #endregion

            using( var cmd = new MySqlCommand( SQL.Update, Connection ) )
            {
                cmd.Parameters.AddWithValue( "@ID", ticket.ID );
                cmd.Parameters.AddWithValue( "@UserID", ticket.Requestor == null ? 1 /* system placeholder */ : ticket.Requestor.ID );
                cmd.Parameters.AddWithValue( "@EquipmentBarCode", ticket.Equipment.BarCode );
                cmd.Parameters.AddWithValue( "@LicenseID", ticket.License == null ? 1 /* system placeholder */ : ticket.License.ID );
                cmd.Parameters.AddWithValue( "@Description", ticket.Description );
                cmd.Parameters.AddWithValue( "@DateCreated", ticket.DateCreated );
                cmd.Parameters.AddWithValue( "@DateClosed", ticket.DateClosed == DateTime.MinValue ? DBNull.Value : (object)ticket.DateClosed );

                // run the update statement
                cmd.ExecuteNonQuery();
            }
        }

        #endregion
    }
}
