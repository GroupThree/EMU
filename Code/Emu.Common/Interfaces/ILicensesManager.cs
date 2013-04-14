using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Emu.Common
{
    public interface ILicensesManager
    {
        List<License> GetLicenses();
        License GetLicense( int barcode );
        void CreateLicense( License license );
        void UpdateLicense( License license );
        void CreateRelationship( License license, Equipment equipment );
    }
}
