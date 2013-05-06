using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Net;
using System.Text;
using System.Web.Mvc;

namespace Emu.Common
{
    public class NetworkAddress
    {
        [Key]
        [HiddenInput(DisplayValue = false)]
        public virtual int NetworkAddressId { get; set; }
        [Required(AllowEmptyStrings=false, ErrorMessage="Please enter an IP Address")]
        public virtual string Address { get; set; }
        public virtual Equipment InstalledOn { get; set; }
    }
}
