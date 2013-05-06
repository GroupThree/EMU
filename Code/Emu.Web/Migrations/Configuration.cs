namespace Emu.Web.Migrations
{
    using Emu.Common;
    using System;
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

        protected override void Seed(EmuDb context)
        {
            if( context.Database.Exists() == false )
            {
                context.Database.Initialize(true);
            }

            context.Softwares.AddOrUpdate(s => s.Description,
                 new Software { EBarCode = 200000, Description = "Microsoft Windows XP", SerialNumber = "asdf1111" },
                 new Software { EBarCode = 200001, Description = "Microsoft Windows 7", SerialNumber = "1111asdf" },
                 new Software { EBarCode = 200002, Description = "Microsoft Word 2007", SerialNumber = "0101asdf" },
                 new Software { EBarCode = 200003, Description = "Microsoft Word 2010", SerialNumber = "1010asdf" }
               );

            context.NetworkAddresses.AddOrUpdate(a => a.Address,
                new NetworkAddress { Address = "10.0.0.1" },
                new NetworkAddress { Address = "10.0.0.2" },
                new NetworkAddress { Address = "10.0.0.3" },
                new NetworkAddress { Address = "10.0.0.4" }
                );

            context.Licenses.AddOrUpdate(lic => lic.LicenseKey,
                new License { LicenseKey = "12345678900987654321", ExpirationDate = DateTime.MaxValue },
                new License { LicenseKey = "09876543211234567890", ExpirationDate = DateTime.MaxValue },
                new License { LicenseKey = "66667777800544332245", ExpirationDate = DateTime.MaxValue },
                new License { LicenseKey = "09871234560987654234", ExpirationDate = DateTime.MaxValue }
                );

            context.Users.AddOrUpdate(u => u.UserName,
                new User { UserName = "bnewton", Password = "12345678", UType = UserType.Admin },
                new User { UserName = "amedury", Password = "12345678", UType = UserType.Admin },
                new User { UserName = "joerter", Password = "12345678", UType = UserType.Basic },
                new User { UserName = "twbrown", Password = "12345678", UType = UserType.Basic }
                );

             context.Equipments.AddOrUpdate(e => e.BarCode, 
                    new Equipment { BarCode = 100000, Category = UsageCategory.Faculty, EDescription = "Brian's Laptop", Location = "Mobile1", SerialNumber = "asdf123456789fdas", WarrantyExpiration = DateTime.Parse("2010-1-1")  },
                    new Equipment { BarCode = 100001, Category = UsageCategory.Faculty, EDescription = "Ajay's Laptop", Location = "Mobile2", SerialNumber = "12345asdffdsa54321", WarrantyExpiration = DateTime.Parse("2010-1-1") },
                    new Equipment { BarCode = 100002, Category = UsageCategory.Faculty, EDescription = "John's Laptop", Location = "Mobile3", SerialNumber = "768490302asdf18993", WarrantyExpiration = DateTime.Parse("2010-1-1") },
                    new Equipment { BarCode = 100003, Category = UsageCategory.Faculty, EDescription = "Tim's Laptop", Location = "Mobile4", SerialNumber = "fdsa12234fdsa23442", WarrantyExpiration = DateTime.Parse("2010-1-1") }
                );
        }

    }
}
