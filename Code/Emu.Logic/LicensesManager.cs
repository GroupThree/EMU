using Emu.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Emu.Logic
{
    public class LicensesManager : ILicensesManager
    {
        public List<License> GetLicenses()
        {
            return new List<License>();
        }

        public License GetLicense( int barcode )
        {
            return null;
        }

        public void CreateLicense( License license )
        {
            
        }

        public void UpdateLicense( License license )
        {
            
        }
    }
}
