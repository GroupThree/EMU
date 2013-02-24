using Emu.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;

namespace Emu.Web.Mockup
{
    public static class Data
    {
        #region users

        static User brian = new User { ID = 1, UserName = "bnewton@unomaha.edu", Type = UserType.AdminUser };
        static User ajay = new User { ID = 2, UserName = "abmedury@unomaha.edu", Type = UserType.AdminUser };
        static User tim = new User { ID = 3, UserName = "twbrown@unomaha.edu", Type = UserType.BasicUser };
        static User john = new User { ID = 4, UserName = "joerter@unomaha.edu", Type = UserType.BasicUser };

        public static List<User> Users
        {
            get 
            {
                return new List<User> 
                    {
                        brian,
                        ajay,
                        tim,
                        john
                    }; 
            }
        }

        #endregion
        #region equipment

        static Equipment brianLaptop = new Equipment { BarCode = 20, Description = "HP Laptop", Location = "Mobile", WarrantyExpiration = DateTime.Parse("2010-01-01"), Licenses = brianLicenses, NetworkAddresses = brianAddresses };
        static Equipment ajayLaptop = new Equipment { BarCode = 20, Description = "Acer Laptop", Location = "Mobile", WarrantyExpiration = DateTime.Parse( "2010-01-01"), Licenses = ajayLicenses, NetworkAddresses = ajayAddresses };
        static Equipment johnLaptop = new Equipment { BarCode = 20, Description = "Dell Laptop", Location = "Mobile", WarrantyExpiration = DateTime.Parse( "2010-01-01"), Licenses = johnLicenses, NetworkAddresses = johnAddresses };
        static Equipment timLaptop = new Equipment { BarCode = 20, Description = "Sony Laptop", Location = "Mobile", WarrantyExpiration = DateTime.Parse( "2010-01-01"), Licenses = timLicenses, NetworkAddresses = timAddresses };

        public static List<Equipment> Equipment
        {
            get
            {
                return new List<Equipment>
                {
                    brianLaptop,
                    ajayLaptop,
                    johnLaptop,
                    timLaptop
                };
            }
        }

        #endregion
        #region software

        static Software office2007 = new Software { BarCode = 5, Description = "Microsoft Office 2007"};
        static Software office2010 = new Software { BarCode = 6, Description = "Microsoft Office 2010" };
        static Software winXP = new Software { BarCode = 7, Description = "Microsoft Windows XP" };
        static Software win7 = new Software { BarCode = 8, Description = "Microsoft Windows 8" };


        public static List<Software> Software
        {
            get
            {
                return new List<Software> 
                    {
                        office2007,
                        office2010,
                        winXP,
                        win7,
                    };
            }
        }

        #endregion
        #region license

        static License winXp_1 = new License { ID = 1, Software = winXP, ExpirationDate = DateTime.MaxValue };
        static License winXp_2 = new License { ID = 2, Software = winXP, ExpirationDate = DateTime.MaxValue };
        static License win7_1 = new License { ID = 3, Software = win7, ExpirationDate = DateTime.MaxValue };
        static License win7_2 = new License { ID = 4, Software = win7, ExpirationDate = DateTime.MaxValue };
        static License office07_1 = new License { ID = 5, Software = office2007, ExpirationDate = DateTime.MaxValue };
        static License office07_2 = new License { ID = 6, Software = office2007, ExpirationDate = DateTime.MaxValue };
        static License office10_1 = new License { ID = 7, Software = office2010, ExpirationDate = DateTime.MaxValue };
        static License office10_2 = new License { ID = 8, Software = office2010, ExpirationDate = DateTime.MaxValue };

        static List<License> brianLicenses = new List<License> { winXp_1, office07_1 };
        static List<License> ajayLicenses = new List<License> { winXp_2, office07_2 };
        static List<License> johnLicenses = new List<License> { win7_1, office10_1 };
        static List<License> timLicenses = new List<License> { win7_2, office10_2 };

        public static List<License> Licenses
        {
            get
            {
                return new List<License>
                {
                    winXp_1,
                    winXp_2,
                    win7_1,
                    win7_2,
                    office07_1,
                    office07_2,
                    office10_1,
                    office10_2
                };
            }
        }

        #endregion
        #region networking

        static NetworkAddress brianAddress = new NetworkAddress { ID = 1, IP = IPAddress.Parse( "10.0.0.1" ), InstalledOn = brianLaptop };
        static NetworkAddress ajayAddress = new NetworkAddress { ID = 1, IP = IPAddress.Parse( "10.0.0.2" ), InstalledOn = ajayLaptop };
        static NetworkAddress johnAddress = new NetworkAddress { ID = 1, IP = IPAddress.Parse( "10.0.0.3" ), InstalledOn = johnLaptop };
        static NetworkAddress timAddress = new NetworkAddress { ID = 1, IP = IPAddress.Parse( "10.0.0.4" ), InstalledOn = timLaptop };

        public static List<NetworkAddress> Addresses
        {
            get
            {
              return new List<NetworkAddress> 
                    {
                        brianAddress,
                        ajayAddress,
                        johnAddress,
                        timAddress
                    };
            }
        }

        static List<NetworkAddress> brianAddresses = new List<NetworkAddress> { brianAddress };
        static List<NetworkAddress> ajayAddresses = new List<NetworkAddress> { ajayAddress };
        static List<NetworkAddress> johnAddresses = new List<NetworkAddress> { johnAddress };
        static List<NetworkAddress> timAddresses = new List<NetworkAddress> { timAddress };

        #endregion
        #region maintenance

        static Ticket brianXpTicket = new Ticket { ID = 1, Equipment = brianLaptop, DateCreated = DateTime.Parse( "2008-01-01" ), DateClosed = DateTime.Parse( "2008-01-02" ), Description = "Install Windows XP on Brian' computer", License = winXp_1, Type = TicketType.AutomaticallyScheduled };
        static Ticket brianOfficeTicket = new Ticket { ID = 2, Equipment = brianLaptop, DateCreated = DateTime.Parse( "2008-01-01" ), DateClosed = DateTime.Parse( "2008-01-02" ), Description = "Install Office 2007 on Brian' computer", License = office07_1, Type = TicketType.AutomaticallyScheduled };
        static Ticket ajayXpTicket = new Ticket { ID = 3, Equipment = ajayLaptop, DateCreated = DateTime.Parse( "2008-01-02" ), DateClosed = DateTime.Parse( "2008-01-03" ), Description = "Install Windows XP on Ajay's computer", License = winXp_2, Type = TicketType.AutomaticallyScheduled };
        static Ticket ajayOfficeTicket = new Ticket { ID = 4, Equipment = ajayLaptop, DateCreated = DateTime.Parse( "2008-01-02" ), DateClosed = DateTime.Parse( "2008-01-03" ), Description = "Install Office 2007 on Ajay's computer", License = office07_1, Type = TicketType.AutomaticallyScheduled };
        static Ticket john7Ticket = new Ticket { ID = 5, Equipment = johnLaptop, DateCreated = DateTime.Parse( "2008-01-03" ), DateClosed = DateTime.Parse( "2008-01-04" ), Description = "Install Windows 7 on John's Computer", License = win7_1, Type = TicketType.AutomaticallyScheduled };
        static Ticket johnOfficeTicket = new Ticket { ID = 6, Equipment = johnLaptop, DateCreated = DateTime.Parse( "2008-01-03" ), DateClosed = DateTime.Parse( "2008-01-04" ), Description = "Install Office 2010 on John's computer", License = office10_1, Type = TicketType.AutomaticallyScheduled };
        static Ticket tim7Ticket = new Ticket { ID = 7, Equipment = timLaptop, DateCreated = DateTime.Parse( "2008-01-03" ), DateClosed = DateTime.Parse( "2008-01-05" ), Description = "Install Windows 7 on Tim's computer", License = win7_2, Type = TicketType.AutomaticallyScheduled };
        static Ticket timOfficeTicket = new Ticket { ID = 8, Equipment = timLaptop, DateCreated = DateTime.Parse( "2008-01-03" ), DateClosed = DateTime.Parse( "2008-01-05" ), Description = "Install Office 2010 on Tim's computer", License = office10_2, Type = TicketType.AutomaticallyScheduled };

        public static List<Ticket> Tickets 
        {
            get 
            {
                return new List<Ticket>
                {
                    brianXpTicket,
                    brianOfficeTicket,
                    ajayXpTicket,
                    ajayOfficeTicket,
                    john7Ticket,
                    johnOfficeTicket,
                    tim7Ticket,
                    timOfficeTicket
                };
            }
        }

        #endregion
    }
}