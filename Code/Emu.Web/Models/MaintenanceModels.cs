using Emu.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Emu.Web.Models
{
    public class MaintenanceModel
    {
        public List<Ticket> Tickets { get; set; }

        public MaintenanceModel()
        {
            Tickets = Mockup.Data.Tickets;
        }
    }
}