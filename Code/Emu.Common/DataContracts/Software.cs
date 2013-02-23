using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Emu.Common
{
    public class Software
    {
        public Guid ID { get; set; }
        public int BarCode { get; set; }
        public string SerialNumber { get; set; }
        public string Description { get; set; }
        public License License { get; set; }
    }
}
