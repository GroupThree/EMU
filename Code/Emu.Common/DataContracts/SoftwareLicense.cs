using System;
using System.Collections.Generic;
using System.ComponentModel;
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
        [DisplayName("Software")]
        public virtual Software Software { get; set; }
        [DisplayName("Installed On")]
        public virtual Equipment InstalledOn { get; set; }
        [DisplayName("LicenseKey")]
        [Required(AllowEmptyStrings=false, ErrorMessage="Please enter a software license key")]
        public virtual string LicenseKey { get; set; }
        [DisplayName("Expiration Date")]
        [DataType(DataType.Date)]
        public virtual DateTime? ExpirationDate { get; set; }
    }
}
