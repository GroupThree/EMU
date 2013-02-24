using Emu.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Emu.Web.Models
{
    public class EquipmentModel
    {
        List<Equipment> Equipment { get; set; }

        public EquipmentModel()
        {
            Equipment = Mockup.Data.Equipment;
        }
    }
}