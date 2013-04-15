using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Emu.Common
{
    public interface ISoftwareManager
    {
        List<Software> Get();
        Software Get( int barcode );
        void Create( Software software );
        void Update( Software software );
    }
}
