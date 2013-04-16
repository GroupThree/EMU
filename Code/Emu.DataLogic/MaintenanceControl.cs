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
            public const string GetAll = @"select
                                                    t.ID as 'TicketID',
                                                    t.Type as 'TicketType',
                                                    t.Description as 'TicketDescription',
                                                    t.DateCreated as 'TicketDateCreated',
                                                    t.DateClosed as 'TicketDateClosed',
                                                    e.BarCode as 'EquipmentBarCode',
                                                    e.SerialNumber as 'EquipmentSerialNumber',
                                                    e.Description as 'EquipmentDescription',
                                                    e.Location as 'EquipmentLocation',
                                                    e.WarrantyExpiration as 'EquipmentWarrantyExpiration',
                                                    s.BarCode as 'SoftwareBarCode',
                                                    s.SerialNumber as 'SoftwareSerialNumber',
                                                    s.Description as 'SoftwareDescription',
                                                    u.ID as 'UserID',
                                                    u.Username as 'UserUserName',
                                                    u.Type as 'UserType'		
                                            from Ticket as t
                                            left join Equipment as e on t.EquipmentBarCode = e.BarCode
                                            left join License as l on t.LicenseID = l.ID
                                            left join Software as s on l.SoftwareBarCode = s.BarCode
                                            left join EmuUser as u on u.ID = t.UserID";
            public const string GetByBarcode = @"select
                                                    t.ID as 'TicketID',
                                                    t.Type as 'TicketType',
                                                    t.Description as 'TicketDescription',
                                                    t.DateCreated as 'TicketDateCreated',
                                                    t.DateClosed as 'TicketDateClosed',
                                                    e.BarCode as 'EquipmentBarCode',
                                                    e.SerialNumber as 'EquipmentSerialNumber',
                                                    e.Description as 'EquipmentDescription',
                                                    e.Location as 'EquipmentLocation',
                                                    e.WarrantyExpiration as 'EquipmentWarrantyExpiration',
                                                    s.BarCode as 'SoftwareBarCode',
                                                    s.SerialNumber as 'SoftwareSerialNumber',
                                                    s.Description as 'SoftwareDescription',
                                                    u.ID as 'UserID',
                                                    u.Username as 'UserUserName',
                                                    u.Type as 'UserType'		
                                            from Ticket as t
                                            left join Equipment as e on t.EquipmentBarCode = e.BarCode
                                            left join License as l on t.LicenseID = l.ID
                                            left join Software as s on l.SoftwareBarCode = s.BarCode
                                            left join EmuUser as u on u.ID = t.UserID
                                            where ticket.ID = @ID";
            public const string Create = @"insert into Ticket
                                            (
                                                UserID, 
                                                EquipmentBarCode,
                                                LicenseID, 
                                                Type, 
                                                Description, 
                                                DateCreated, 
                                                DateClosed
                                            )
                                                values 
                                            (
                                                @UserID, 
                                                @EquipmentBarCode, 
                                                @LicenseID, 
                                                @Type, 
                                                @Description, 
                                                @DateCreated,
                                                @DateClosed
                                            )";
            public const string Update = @"update 
                                                   Ticket
                                           set
                                                   UserID = @UserID,
                                                   EquipmentBarCode = @EquipmentBarCode, 
                                                   LicenseID = @LicenseID,
                                                   Type = @Type,
                                                   Description = @Description,
                                                   DateCreated = @DateCreated,
                                                   DateClosed = @DateClosed 
                                           where
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

        }

        public void Update( Ticket ticket )
        {
            #region Validate Arguments

            #endregion

        }

        #endregion
    }
}
