using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Emu.Common
{
    public class Ticket
    {
        public virtual int Id { get; set; }
        public virtual User Requestor { get; set; }
        public virtual User AssignedTo { get; set; }
        public virtual TicketType Type { get; set; }
        public virtual TicketPiority Priority { get; set; }
        public virtual string Description { get; set; }
        public virtual DateTime DateCreated { get; set; }
        public virtual DateTime DateClosed { get; set; }
    }

    public enum TicketType : int
    {
        AutomaticallyScheduled = 0,
        UserRequested = 1
    }

    public enum TicketPiority : int
    {
        Low = 1,
        Medium = 2,
        High = 3
    }
}
