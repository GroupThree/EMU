using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Emu.Common
{
    public class SoftwareLicense
    {
        [Key]
        [HiddenInput(DisplayValue=false)]
        public virtual int SoftwareLicenseId { get; set; }
        public virtual Software Software { get; set; }
        public virtual Equipment InstalledOn { get; set; }
        [Required(AllowEmptyStrings=false, ErrorMessage="Please enter a software license key")]
        public virtual string LicenseKey { get; set; }
        [DataType(DataType.Date)]
        public virtual DateTime? ExpirationDate { get; set; }
    }
}
