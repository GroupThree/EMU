using System;
using System.Collections.Generic;
using System.ComponentModel;
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
        [DisplayName("Address")]
        [RegularExpression(@"^(?:[0-9]{1,3}\.){3}[0-9]{1,3}$", ErrorMessage="Please enter a valid IP address")]
        public virtual string Address { get; set; }
        [DisplayName("InstalledOn")]
        public virtual Equipment InstalledOn { get; set; }
    }
}
