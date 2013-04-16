using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Emu.Common
{
    public interface ILicensesManager
    {
        List<License> Get();
        License Get( int barcode );
        void Create( License license );
        void Update( License license );
    }
}
