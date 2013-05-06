using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Emu.Common
{
    public class Software
    {
        public virtual int Id { get; set; }
        public virtual int EBarCode { get; set; }
        public virtual string SerialNumber { get; set; }
        public virtual string Description { get; set; }
    }
}
