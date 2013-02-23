using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Emu.Common
{
    public class Ticket
    {
        public Guid ID { get; set; }
        public Guid EquipmentID { get; set; }
        public Guid SoftwareID { get; set; }
        public Guid LicenseID { get; set; }
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
