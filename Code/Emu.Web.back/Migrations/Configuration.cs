namespace Emu.Web.Migrations
{
    using Emu.Common;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using System.Net;
    using System.Web.Security;

    internal sealed class Configuration : DbMigrationsConfiguration<Emu.Web.Infrastructure.EmuDb>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(Emu.Web.Infrastructure.EmuDb context)
        {
            context.NetworkAddresses.AddOrUpdate(na => na.Address,
                    new NetworkAddress { Address = "10.0.0.1", InstalledOn = new Equipment { BarCode = 100000 } },
                    new NetworkAddress { Address = "10.0.0.2", InstalledOn = new Equipment { BarCode = 100001 } },
                    new NetworkAddress { Address = "10.0.0.3", InstalledOn = new Equipment { BarCode = 100002 } },
                    new NetworkAddress { Address = "10.0.0.4", InstalledOn = new Equipment { BarCode = 100003 } }
                );

            context.Software.AddOrUpdate(s => s.Description,
                new Software { BarCode = 200000, Description = "Microsoft Windows XP", SerialNumber = "asdf1111" },
                new Software { BarCode = 200001, Description = "Microsoft Windows 7", SerialNumber = "1111asdf" },
                new Software { BarCode = 200002, Description = "Microsoft Word 2007", SerialNumber = "0101asdf" },
                new Software { BarCode = 200003, Description = "Microsoft Word 2010", SerialNumber = "1010asdf" }
              );

            //context.Equipment.AddOrUpdate(e => e.Description,
            //        new Equipment { BarCode = 100000, Description = "Brian's Computer", Location = "Mobile", SerialNumber = "deadbeef1111", WarrantyExpiration = DateTime.MaxValue, UsedBy = new List<User> { new User { UserName = "bnewton" } } },
            //        new Equipment { BarCode = 100001, Description = "Ajays's Computer", Location = "Mobile", SerialNumber = "1111deadbeef", WarrantyExpiration = DateTime.MaxValue, UsedBy = new List<User> { new User { UserName = "amedury" } } },
            //        new Equipment { BarCode = 100002, Description = "Brian's Computer", Location = "Mobile", SerialNumber = "asdf0011asdf", WarrantyExpiration = DateTime.MaxValue, UsedBy = new List<User> { new User { UserName = "joerter" } } },
            //        new Equipment { BarCode = 100003, Description = "Brian's Computer", Location = "Mobile", SerialNumber = "asdf1100asdf", WarrantyExpiration = DateTime.MaxValue, UsedBy = new List<User> { new User { UserName = "twbrown" } } }
            //    );

            if( Roles.RoleExists("Admin") == false )
            {
                Roles.CreateRole("Admin");
            }

            if( Membership.GetUser("bnewton") == null )
            {
                Membership.CreateUser("bnewton", "12345678");
                Roles.AddUserToRole("bnewton", "Admin");
            }

            if( Membership.GetUser("amedury") == null )
            {
                Membership.CreateUser("amedury", "12345678");
                Roles.AddUserToRole("amedury", "Admin");
            }

            if( Membership.GetUser("joerter") == null )
            {
                Membership.CreateUser("joerter", "12345678");
            }

            if( Membership.GetUser("twbrown") == null )
            {
                Membership.CreateUser("twbrown", "12345678");
            }
        }
    }
}
