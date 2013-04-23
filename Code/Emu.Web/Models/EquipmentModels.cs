using Emu.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Emu.Web.Models
{
    public class EquipmentModel
    {
        public List<Equipment> Equipment { get; set; }
    }

    public class EquipmentCreateEditModel
    {
        public Equipment Equipment { get; set; }
        public List<SelectListItem> AvailableUsers { get; set; }
    }
}