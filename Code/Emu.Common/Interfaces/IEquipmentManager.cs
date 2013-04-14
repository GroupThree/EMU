using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Emu.Common
{
    public interface IEquipmentManager
    {
        List<Equipment> GetEquipment();
        Equipment GetEquipment( int barcode );
        void CreateEquipment( Equipment equipment );
        void UpdateEquipment( Equipment equipment );
        void CreateRelationship( Equipment equipment, User user );
    }
}
