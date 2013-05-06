using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Emu.Common
{
    public class License
    {
        public virtual int Id { get; set; }
        public virtual Software Software { get; set; }
        public virtual string LicenseKey { get; set; }
        public virtual DateTime? ExpirationDate { get; set; }
    }
}
