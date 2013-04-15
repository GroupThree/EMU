using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Emu.Common
{
    public interface IEquipmentManager
    {
        List<Equipment> Get();
        Equipment Get( int barcode );
        void Create( Equipment equipment );
        void Update( Equipment equipment );
        void CreateRelationship( Equipment equipment, User user );
    }
}
