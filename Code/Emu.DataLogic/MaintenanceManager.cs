using Emu.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Emu.Logic
{
    public class MaintenanceManager : IMaintenanceManager
    {
        public List<Ticket> GetTickets()
        {
            return new List<Ticket>();
        }

        public Ticket GetTicket(int id)
        {
            return null;
        }

        public void CreateTicket( Ticket ticket )
        {
            
        }

        public void UpdateTicket( Ticket ticket )
        {
            
        }
    }
}
