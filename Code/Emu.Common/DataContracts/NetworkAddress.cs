using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;

namespace Emu.Common.DataContracts
{
    public class NetworkAddress
    {
        public int ID { get; set; }
        public IPAddress IP { get; set; }

        public Equipment InstalledOn { get; set; }
    }
}
