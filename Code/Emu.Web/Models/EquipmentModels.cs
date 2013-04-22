using Emu.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Emu.Web.Models
{
    public class EquipmentModel
    {
        public List<Equipment> Equipment { get; set; }
    }

    public class EquipmentEditModel
    {
        public Equipment Equipment { get; set; }
        public List<User> AvailableUsers { get; set; }
    }
}