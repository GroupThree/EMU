using Emu.Common;
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
            Connection = new MySqlConnection( "connection_string" );
        }

        #endregion
        #region Methods
        
        public List<Ticket> Get()
        {
            var results = new List<Ticket>();

            return results;
        }

        public Ticket Get(int id)
        {
            #region Validate Arguments

            #endregion

            Ticket result = null;
            
            return result;
        }

        public void Create( Ticket ticket )
        {
            #region Validate Arguments

            #endregion

            using( var cmd = new MySqlCommand( SQL.Create, Connection ) )
            {
                cmd.Parameters.AddWithValue( "@ID", ticket.ID );
                cmd.Parameters.AddWithValue( "@UserID", 1 ); // TODO: Fix This
                cmd.Parameters.AddWithValue( "@LicenseID", 1 ); // TODO: Fix This
                cmd.Parameters.AddWithValue( "@Description", ticket.Description );
                cmd.Parameters.AddWithValue( "@DateCreated", ticket.DateClosed );
                cmd.Parameters.AddWithValue( "@DateClosed", ticket.DateClosed );

                // run the update statement
                cmd.ExecuteNonQuery();
            }
        }

        public void Update( Ticket ticket )
        {
            #region Validate Arguments

            #endregion

            using( var cmd = new MySqlCommand( SQL.Update, Connection ) )
            {
                cmd.Parameters.AddWithValue( "@ID", ticket.ID );
                cmd.Parameters.AddWithValue( "@UserID", 1 ); // TODO: Fix This
                cmd.Parameters.AddWithValue( "@LicenseID", 1 ); // TODO: Fix This
                cmd.Parameters.AddWithValue( "@Description", ticket.Description );
                cmd.Parameters.AddWithValue( "@DateCreated", ticket.DateClosed );
                cmd.Parameters.AddWithValue( "@DateClosed", ticket.DateClosed );

                // run the update statement
                cmd.ExecuteNonQuery();
            }
        }

        #endregion
    }
}
