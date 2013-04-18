using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Emu.Common
{
    public interface INetworkingManager
    {
        List<NetworkAddress> Get();
        NetworkAddress Get( int id );
        void Create( NetworkAddress address );
        void Update( NetworkAddress address );
    }
}
