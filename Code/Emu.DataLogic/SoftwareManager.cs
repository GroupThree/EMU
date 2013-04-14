using Emu.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Emu.Logic
{
    public class SoftwareManager : ISoftwareManager
    {
        public List<Software> GetSoftware()
        {
            return new List<Software>();
        }

        public Software GetSoftware( int barcode )
        {
            return null;
        }

        public void CreateSoftware( Software software )
        {
            
        }

        public void UpdateSoftware( Software software )
        {
            
        }
    }
}
