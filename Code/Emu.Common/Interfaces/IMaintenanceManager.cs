using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Emu.Common
{
    public interface IMaintenanceManager
    {
        List<Ticket> GetTickets();
        Ticket GetTicket(int id);
        void CreateTicket( Ticket ticket );
        void UpdateTicket( Ticket ticket );
    }
}
