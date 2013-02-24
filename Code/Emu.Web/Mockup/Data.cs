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
        #region static constructor

        static Data()
        {

        }

        #endregion

        #region users

        static User brian { get { return new User { ID = 1, UserName = "bnewton@unomaha.edu", Type = UserType.AdminUser }; } }
        static User ajay { get { return new User { ID = 2, UserName = "abmedury@unomaha.edu", Type = UserType.AdminUser }; } }
        static User tim { get { return new User { ID = 3, UserName = "twbrown@unomaha.edu", Type = UserType.BasicUser }; } }
        static User john { get { return new User { ID = 4, UserName = "joerter@unomaha.edu", Type = UserType.BasicUser }; } }

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

        static Equipment brianLaptop { get { return new Equipment { BarCode = 20, Description = "HP Laptop", Location = "Mobile", WarrantyExpiration = expDate1, Licenses = brianLicenses, NetworkAddresses = brianAddresses }; } }
        static Equipment ajayLaptop { get { return new Equipment { BarCode = 21, Description = "Acer Laptop", Location = "Mobile", WarrantyExpiration = expDate2, Licenses = ajayLicenses, NetworkAddresses = ajayAddresses }; } }
        static Equipment johnLaptop { get { return new Equipment { BarCode = 22, Description = "Dell Laptop", Location = "Mobile", WarrantyExpiration = expDate3, Licenses = johnLicenses, NetworkAddresses = johnAddresses }; } }
        static Equipment timLaptop { get { return new Equipment { BarCode = 23, Description = "Sony Laptop", Location = "Mobile", WarrantyExpiration = expDate4, Licenses = timLicenses, NetworkAddresses = timAddresses }; } }

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

        static Software office2007 { get { return new Software { BarCode = 5, Description = "Microsoft Office 2007" }; } }
        static Software office2010 { get { return new Software { BarCode = 6, Description = "Microsoft Office 2010" }; } }
        static Software winXP { get { return new Software { BarCode = 7, Description = "Microsoft Windows XP" }; } }
        static Software win7 { get { return new Software { BarCode = 8, Description = "Microsoft Windows 8" }; } }


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

        static License winXp_1 { get { return new License { ID = 1, Software = winXP, ExpirationDate = DateTime.MaxValue }; } }
        static License winXp_2 { get { return new License { ID = 2, Software = winXP, ExpirationDate = DateTime.MaxValue }; } }
        static License win7_1 { get { return new License { ID = 3, Software = win7, ExpirationDate = DateTime.MaxValue }; } }
        static License win7_2 { get { return new License { ID = 4, Software = win7, ExpirationDate = DateTime.MaxValue }; } }
        static License office07_1 { get { return new License { ID = 5, Software = office2007, ExpirationDate = DateTime.MaxValue }; } }
        static License office07_2 { get { return new License { ID = 6, Software = office2007, ExpirationDate = DateTime.MaxValue }; } }
        static License office10_1 { get { return new License { ID = 7, Software = office2010, ExpirationDate = DateTime.MaxValue }; } }
        static License office10_2 { get { return new License { ID = 8, Software = office2010, ExpirationDate = DateTime.MaxValue }; } }

        static List<License> brianLicenses { get { return new List<License> { winXp_1, office07_1 }; } }
        static List<License> ajayLicenses { get { return new List<License> { winXp_2, office07_2 }; } }
        static List<License> johnLicenses { get { return new List<License> { win7_1, office10_1 }; } }
        static List<License> timLicenses { get { return new List<License> { win7_2, office10_2 }; } }

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

        static NetworkAddress brianAddress { get { return new NetworkAddress { ID = 1, IP = brianIP/* , InstalledOn = brianLaptop */ }; } }
        static NetworkAddress ajayAddress { get { return new NetworkAddress { ID = 1, IP = ajayIP/* , InstalledOn = ajayLaptop */ }; } }
        static NetworkAddress johnAddress { get { return new NetworkAddress { ID = 1, IP = johnIP /* , InstalledOn = johnLaptop */ }; } }
        static NetworkAddress timAddress { get { return new NetworkAddress { ID = 1, IP = timIP /* , InstalledOn = timLaptop */ }; } }

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

        static List<NetworkAddress> brianAddresses { get { return new List<NetworkAddress> { brianAddress }; } }
        static List<NetworkAddress> ajayAddresses { get { return new List<NetworkAddress> { ajayAddress }; } }
        static List<NetworkAddress> johnAddresses { get { return new List<NetworkAddress> { johnAddress }; } }
        static List<NetworkAddress> timAddresses { get { return new List<NetworkAddress> { timAddress }; } }

        #endregion
        #region maintenance

        static Ticket brianXpTicket { get { return new Ticket { ID = 1, /* Equipment = brianLaptop, */ DateCreated = dateCreated1, DateClosed = dateCreated1, Description = "Install Windows XP on Brian' computer", License = winXp_1, Type = TicketType.AutomaticallyScheduled }; } }
        static Ticket brianOfficeTicket { get { return new Ticket { ID = 2, /* Equipment = brianLaptop, */ DateCreated = dateCreated1, DateClosed = dateClosed1, Description = "Install Office 2007 on Brian' computer", License = office07_1, Type = TicketType.AutomaticallyScheduled }; } }
        static Ticket ajayXpTicket { get { return new Ticket { ID = 3, /* Equipment = ajayLaptop, */ DateCreated = dateCreated2, DateClosed = dateClosed2, Description = "Install Windows XP on Ajay's computer", License = winXp_2, Type = TicketType.AutomaticallyScheduled }; } }
        static Ticket ajayOfficeTicket { get { return new Ticket { ID = 4, /* Equipment = ajayLaptop, */ DateCreated = dateCreated2, DateClosed = dateClosed2, Description = "Install Office 2007 on Ajay's computer", License = office07_1, Type = TicketType.AutomaticallyScheduled }; } }
        static Ticket john7Ticket { get { return new Ticket { ID = 5, /* Equipment = johnLaptop, */ DateCreated = dateCreated3, DateClosed = dateClosed3, Description = "Install Windows 7 on John's Computer", License = win7_1, Type = TicketType.AutomaticallyScheduled }; } }
        static Ticket johnOfficeTicket { get { return new Ticket { ID = 6, /* Equipment = johnLaptop, */ DateCreated = dateCreated3, DateClosed = dateClosed3, Description = "Install Office 2010 on John's computer", License = office10_1, Type = TicketType.AutomaticallyScheduled }; } }
        static Ticket tim7Ticket { get { return new Ticket { ID = 7, /* Equipment = timLaptop, */ DateCreated = dateCreated4, DateClosed = dateClosed4, Description = "Install Windows 7 on Tim's computer", License = win7_2, Type = TicketType.AutomaticallyScheduled }; } }
        static Ticket timOfficeTicket { get { return new Ticket { ID = 8, /* Equipment = timLaptop, */DateCreated = dateCreated4, DateClosed = dateClosed4, Description = "Install Office 2010 on Tim's computer", License = office10_2, Type = TicketType.AutomaticallyScheduled }; } }

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
        #region misc

        static IPAddress brianIP { get { return IPAddress.Parse( "10.0.0.1" ); } }
        static IPAddress ajayIP { get { return IPAddress.Parse( "10.0.0.2" ); } }
        static IPAddress johnIP { get { return IPAddress.Parse( "10.0.0.3" ); } }
        static IPAddress timIP { get { return IPAddress.Parse( "10.0.0.4" ); } }

        static DateTime expDate1 { get { return DateTime.Parse( "2010-01-01" ); } }
        static DateTime expDate2 { get { return DateTime.Parse( "2010-01-01" ); } }
        static DateTime expDate3 { get { return DateTime.Parse( "2011-01-01" ); } }
        static DateTime expDate4 { get { return DateTime.Parse( "2011-01-01" ); } }

        static DateTime dateCreated1 { get { return DateTime.Parse( "2008-01-01" ); } }
        static DateTime dateCreated2 { get { return DateTime.Parse( "2008-01-02" ); } }
        static DateTime dateCreated3 { get { return DateTime.Parse( "2008-01-03" ); } }
        static DateTime dateCreated4 { get { return DateTime.Parse( "2008-01-04" ); } }

        static DateTime dateClosed1 { get { return DateTime.Parse( "2008-01-02" ); } }
        static DateTime dateClosed2 { get { return DateTime.Parse( "2008-01-03" ); } }
        static DateTime dateClosed3 { get { return DateTime.Parse( "2008-01-04" ); } }
        static DateTime dateClosed4 { get { return DateTime.Parse( "2008-01-05" ); } }

        #endregion
    }
}