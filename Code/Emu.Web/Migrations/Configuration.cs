namespace Emu.Web.Migrations
{
    using Emu.Common;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using System.Web.Security;
    using WebMatrix.WebData;

    internal sealed class Configuration : DbMigrationsConfiguration<Emu.Web.EmuDb>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        #region network addresses

        NetworkAddress na1 = new NetworkAddress { Address = "10.0.0.1" };
        NetworkAddress na2 = new NetworkAddress { Address = "10.0.0.2" };
        NetworkAddress na3 = new NetworkAddress { Address = "10.0.0.3" };
        NetworkAddress na4 = new NetworkAddress { Address = "10.0.0.4" };

        #endregion

        #region software
        Software s1 = new Software { SoftwareBarCode = 200000, SoftwareDescription = "Microsoft Windows XP", SoftwareSerialNumber = "asdf1111" };
        Software s2 = new Software { SoftwareBarCode = 200001, SoftwareDescription = "Microsoft Windows 7", SoftwareSerialNumber = "1111asdf" };
        Software s3 = new Software { SoftwareBarCode = 200002, SoftwareDescription = "Microsoft Word 2007", SoftwareSerialNumber = "0101asdf" };
        Software s4 = new Software { SoftwareBarCode = 200003, SoftwareDescription = "Microsoft Word 2010", SoftwareSerialNumber = "1010asdf" };
        #endregion

        #region software licenses

        SoftwareLicense sl1 = new SoftwareLicense { LicenseKey = "deadbeef1234", ExpirationDate = DateTime.MaxValue };
        SoftwareLicense sl2 = new SoftwareLicense { LicenseKey = "deadbeef4321", ExpirationDate = DateTime.MaxValue };
        SoftwareLicense sl3 = new SoftwareLicense { LicenseKey = "1234deadbeef", ExpirationDate = DateTime.MaxValue };
        SoftwareLicense sl4 = new SoftwareLicense { LicenseKey = "4321deadbeef", ExpirationDate = DateTime.MaxValue };
        SoftwareLicense sl5 = new SoftwareLicense { LicenseKey = "deadbea71234", ExpirationDate = DateTime.MaxValue };
        SoftwareLicense sl6 = new SoftwareLicense { LicenseKey = "deadbea74321", ExpirationDate = DateTime.MaxValue };
        SoftwareLicense sl7 = new SoftwareLicense { LicenseKey = "1234deadbea7", ExpirationDate = DateTime.MaxValue };
        SoftwareLicense sl8 = new SoftwareLicense { LicenseKey = "4321deadbea7", ExpirationDate = DateTime.MaxValue };

        #endregion

        #region users

        User u1 = new User { UserName = "bnewton", Password = "12345678", UserType = UserType.Admin };
        User u2 = new User { UserName = "amedury", Password = "12345678", UserType = UserType.Admin };
        User u3 = new User { UserName = "joerter", Password = "12345678", UserType = UserType.Basic };
        User u4 = new User { UserName = "twbrown", Password = "12345678", UserType = UserType.Basic };

        #endregion

        #region equipment

        Equipment e1 = new Equipment { EquipmentBarCode = 100000, Category = UsageCategory.Faculty, EquipmentDescription = "Brian's Laptop", EquipmentLocation = "Mobile", EquipmentSerialNumber = "a1b2c3d4", WarrantyExpiration = DateTime.Parse("2010-1-1") };
        Equipment e2 = new Equipment { EquipmentBarCode = 100001, Category = UsageCategory.Faculty, EquipmentDescription = "Ajay's Laptop", EquipmentLocation = "Mobile", EquipmentSerialNumber = "1a2b3c4d", WarrantyExpiration = DateTime.Parse("2010-1-1") };
        Equipment e3 = new Equipment { EquipmentBarCode = 100002, Category = UsageCategory.Faculty, EquipmentDescription = "John's Laptop", EquipmentLocation = "Mobile", EquipmentSerialNumber = "d4c3b2a1", WarrantyExpiration = DateTime.Parse("2010-1-1") };
        Equipment e4 = new Equipment { EquipmentBarCode = 100003, Category = UsageCategory.Faculty, EquipmentDescription = "Tim's Laptop", EquipmentLocation = "Mobile", EquipmentSerialNumber = "4d3c2b1a", WarrantyExpiration = DateTime.Parse("2010-1-1") };

        #endregion

        #region tickets

        Ticket t1 = new Ticket { TicketDescription = "a", Type = TicketType.UserRequested, Priority = TicketPiority.Medium, TicketCreated = DateTime.Parse("2013-1-1") };
        Ticket t2 = new Ticket { TicketDescription = "b", Type = TicketType.UserRequested, Priority = TicketPiority.Medium, TicketCreated = DateTime.Parse("2013-1-1") };
        Ticket t3 = new Ticket { TicketDescription = "c", Type = TicketType.UserRequested, Priority = TicketPiority.Medium, TicketCreated = DateTime.Parse("2013-1-1") };
        Ticket t4 = new Ticket { TicketDescription = "d", Type = TicketType.UserRequested, Priority = TicketPiority.Medium, TicketCreated = DateTime.Parse("2013-1-1") };
        Ticket t5 = new Ticket { TicketDescription = "e", Type = TicketType.UserRequested, Priority = TicketPiority.Medium, TicketCreated = DateTime.Parse("2013-1-1") };
        Ticket t6 = new Ticket { TicketDescription = "f", Type = TicketType.UserRequested, Priority = TicketPiority.Medium, TicketCreated = DateTime.Parse("2013-1-1") };
        Ticket t7 = new Ticket { TicketDescription = "g", Type = TicketType.UserRequested, Priority = TicketPiority.Medium, TicketCreated = DateTime.Parse("2013-1-1") };
        Ticket t8 = new Ticket { TicketDescription = "h", Type = TicketType.UserRequested, Priority = TicketPiority.Medium, TicketCreated = DateTime.Parse("2013-1-1") };

        #endregion

        protected override void Seed(EmuDb context)
        {
            if( context.Database.Exists() == false )
            {
                context.Database.Initialize(true);
            }

            s1.Licenses.Add(sl1);
            s1.Licenses.Add(sl2);
            s2.Licenses.Add(sl3);
            s2.Licenses.Add(sl4);
            s3.Licenses.Add(sl5);
            s3.Licenses.Add(sl6);
            s4.Licenses.Add(sl7);
            s4.Licenses.Add(sl8);

            e1.NetworkAddresses.Add(na1);
            e1.UsedBy.Add(u1);
            u1.Equipments.Add(e1);
            e1.SoftwareLicenses.Add(sl1);
            e1.SoftwareLicenses.Add(sl5);

            e2.NetworkAddresses.Add(na2);
            e2.UsedBy.Add(u2);
            u2.Equipments.Add(e2);
            e2.SoftwareLicenses.Add(sl2);
            e2.SoftwareLicenses.Add(sl6);

            e3.NetworkAddresses.Add(na3);
            e3.UsedBy.Add(u3);
            u3.Equipments.Add(e3);
            e3.SoftwareLicenses.Add(sl3);
            e3.SoftwareLicenses.Add(sl7);

            e4.NetworkAddresses.Add(na4);
            e4.UsedBy.Add(u4);
            u4.Equipments.Add(e4);
            e4.SoftwareLicenses.Add(sl4);
            e4.SoftwareLicenses.Add(sl8);

            t1.AssignedTo = u1;
            t1.Requestor = u1;
            u1.RequestedTickets.Add(t1);
            u1.AssignedTickets.Add(t1);

            t2.AssignedTo = u1;
            t2.Requestor = u1;
            u1.AssignedTickets.Add(t2);
            u1.RequestedTickets.Add(t2);

            t3.AssignedTo = u2;
            t3.Requestor = u2;
            u2.AssignedTickets.Add(t3);
            u2.RequestedTickets.Add(t3);

            t4.AssignedTo = u2;
            t4.Requestor = u2;
            u2.AssignedTickets.Add(t4);
            u2.RequestedTickets.Add(t4);

            t5.AssignedTo = u1;
            t5.Requestor = u3;
            u1.AssignedTickets.Add(t5);
            u3.RequestedTickets.Add(t5);

            t6.AssignedTo = u1;
            t6.Requestor = u3;
            u1.AssignedTickets.Add(t6);
            u3.RequestedTickets.Add(t6);

            t7.AssignedTo = u2;
            t7.Requestor = u4;
            u2.AssignedTickets.Add(t7);
            u4.RequestedTickets.Add(t7);

            t8.AssignedTo = u2;
            t8.Requestor = u4;
            u2.AssignedTickets.Add(t8);
            u4.RequestedTickets.Add(t8);

            context.Users.AddOrUpdate(u => u.UserName, u1, u2, u3, u4);

            context.Equipments.AddOrUpdate(e => e.EquipmentBarCode, e1, e2, e3, e4);
            
            context.NetworkAddresses.AddOrUpdate(a => a.Address, na1, na2, na3, na4);

            context.Softwares.AddOrUpdate( s => s.SoftwareDescription, s1, s2, s3, s4 );

            context.Licenses.AddOrUpdate( lic => lic.LicenseKey, sl1, sl2, sl3, sl4 );

            context.Tickets.AddOrUpdate(t => t.TicketDescription, t1, t2, t3, t4, t5, t6, t7, t8);
        }

    }
}
