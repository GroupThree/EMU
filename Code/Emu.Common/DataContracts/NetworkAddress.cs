using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Net;
using System.Text;

namespace Emu.Common
{
    public class NetworkAddress
    {
        public virtual int Id { get; set; }
        public virtual string Address { get; set; }
        public virtual Equipment InstalledOn { get; set; }
    }
}
