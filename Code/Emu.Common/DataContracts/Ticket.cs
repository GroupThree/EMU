using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Emu.Common
{
    public class Ticket
    {
        public int ID { get; set; }
        public Equipment Equipment { get; set; }
        public License License { get; set; }
        public TicketType Type { get; set; }
        public string Description { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime DateClosed { get; set; }
    }

    public enum TicketType : int
    {
        AutomaticallyScheduled = 0,
        UserRequested = 1
    }
}
