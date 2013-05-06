using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Emu.Common
{
    public interface IEmuDataSource
    {
        IQueryable<Equipment> Equipment { get; }
        IQueryable<User> Users { get; }
        IQueryable<Ticket> Tickets { get; }
        IQueryable<Software> Software { get; }
        IQueryable<SoftwareLicense> Licenses { get; }
        IQueryable<NetworkAddress> NetworkAddresses { get; }

        void Save();
    }
}
