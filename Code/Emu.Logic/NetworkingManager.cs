using Emu.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Emu.Logic
{
    public class NetworkingManager : INetworkingManager
    {

        public List<NetworkAddress> GetAddresses()
        {
            return new List<NetworkAddress>();
        }

        public NetworkAddress GetAddress( int id )
        {
            return null;
        }

        public void CreateNetworkAddress( NetworkAddress address )
        {
            
        }

        public void UpdateNetworkAddress( NetworkAddress address )
        {
            
        }
    }
}
