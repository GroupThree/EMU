using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Emu.Common
{
    public class Software
    {
        [Key]
        [HiddenInput(DisplayValue = false)]
        public virtual int SoftwareId { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "Please enter a software bar code")]
        public virtual int SoftwareBarCode { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "Please enter a software serial number")]
        public virtual string SoftwareSerialNumber { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "Please enter a software description")]
        public virtual string SoftwareDescription { get; set; }
        public virtual ICollection<SoftwareLicense> Licenses { get; set; }

        public Software()
        {
            //Licenses = new List<SoftwareLicense>();
        }
    }
}
