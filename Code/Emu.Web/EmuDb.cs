using Emu.Common;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Emu.Web
{
    public class EmuDb : DbContext
    {
        public EmuDb() : base("DefaultConnection") { }

        public DbSet<Equipment> Equipments { get; set; }
        public DbSet<Ticket> Tickets { get; set; }
        public DbSet<Software> Softwares { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<NetworkAddress> NetworkAddresses { get; set; }
        public DbSet<SoftwareLicense> Licenses { get; set; }

        protected override void OnModelCreating( DbModelBuilder modelBuilder )
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Ticket>()
                .HasRequired(ticket => ticket.AssignedTo)
                .WithMany(user => user.AssignedTickets)
                .HasForeignKey(ticket => ticket.AssignedToId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Ticket>()
                .HasRequired(ticket => ticket.Requestor)
                .WithMany(user => user.RequestedTickets)
                .HasForeignKey(ticket => ticket.RequestorId)
                .WillCascadeOnDelete(false);
        }
    }
}