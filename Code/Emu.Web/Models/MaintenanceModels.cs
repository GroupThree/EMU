using Emu.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Emu.Web.Models
{
    public class MaintenanceModel
    {
        public List<Ticket> Tickets { get; set; }
    }

    public class MaintenanceCreateModel
    {
        public Ticket Ticket { get; set; }
        public List<SelectListItem> AvailableEquipment { get; set; }
    }

    public class MaintenanceEditModel
    {
        public Ticket Ticket { get; set; }
        public List<SelectListItem> AvailableEquipment { get; set; }
        public List<SelectListItem> AvailableLicense { get; set; }
    }
}