using Emu.Common;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Emu.Web.Infrastructure
{
    public class EmuDb : DbContext, IEmuDataSource
    {
        public DbSet<Equipment> Equipment { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Ticket> Tickets { get; set; }
        public DbSet<Software> Software { get; set; }
        public DbSet<License> Licenses { get; set; }
        public DbSet<NetworkAddress> NetworkAddresses { get; set; }

        public EmuDb() : base("DefaultConnection") { }

        IQueryable<Equipment> IEmuDataSource.Equipment
        {
            get
            {
                return Equipment;
            }
        }

        IQueryable<User> IEmuDataSource.Users
        {
            get
            {
                return Users;
            }
        }

        IQueryable<Ticket> IEmuDataSource.Tickets
        {
            get
            {
                return Tickets;
            }
        }

        IQueryable<Software> IEmuDataSource.Software
        {
            get
            {
                return Software;
            }
        }

        IQueryable<License> IEmuDataSource.Licenses
        {
            get
            {
                return Licenses;
            }
        }

        IQueryable<NetworkAddress> IEmuDataSource.NetworkAddresses
        {
            get
            {
                return NetworkAddresses;
            }
        }

        void IEmuDataSource.Save()
        {
            SaveChanges();
        }
    }
}