using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Emu.Common
{
    public class Equipment
    {
        public Guid ID { get; set; }
        public int BarCode { get; set; }
        public string Description { get; set; }
        public string Location { get; set; }
        public DateTime WarrentyExpiration { get; set; }

        public List<Software> InstalledSoftware { get; set; }
    }
}
