using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Emu.Common
{
    public interface ISoftwareManager
    {
        List<Software> GetSoftware();
        Software GetSoftware( int barcode );
        void CreateSoftware( Software software );
        void UpdateSoftware( Software software );
    }
}
