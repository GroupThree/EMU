using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Emu.Common
{
    public class License
    {
        public int ID { get; set; }
        public Software Software { get; set; }
        public string LicenseKey { get; set; }
        public DateTime ExpirationDate { get; set; }
    }
}
