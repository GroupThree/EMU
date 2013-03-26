using Emu.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Emu.Logic
{
    public class EquipmentManager : IEquipmentManager
    {
        public List<Equipment> GetEquipment()
        {
            return new List<Equipment>();
        }

        public Equipment GetEquipment( int barcode )
        {
            return null;
        }

        public void CreateEquipment( Equipment equipment )
        {
            
        }

        public void UpdateEquipment( Equipment equipment )
        {
            
        }
    }
}
