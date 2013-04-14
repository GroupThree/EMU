using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Emu.Common
{
    public interface INetworkingManager
    {
        List<NetworkAddress> GetAddresses();
        NetworkAddress GetAddress( int id );
        void CreateNetworkAddress( NetworkAddress address );
        void UpdateNetworkAddress( NetworkAddress address );
        void CreateRelationship( NetworkAddress address, Equipment equipment );
    }
}
