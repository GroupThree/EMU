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
    public class Equipment
    {
        [Key]
        [HiddenInput(DisplayValue = false)]
        public virtual int EquipmentId { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "Please enter an equipment bar code")]
        [DisplayName("BarCode")]
        public virtual int EquipmentBarCode { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "Please enter an equipment serial number")]
        [DisplayName("SerialNumber")]
        public virtual string EquipmentSerialNumber { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "Please enter an equipment description")]
        [DisplayName("Description")]
        public virtual string EquipmentDescription { get; set; }
        [DisplayName("Category")]
        public virtual UsageCategory Category { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "Please enter an equipment location")]
        [DisplayName("Location")]
        public virtual string EquipmentLocation { get; set; }
        [Required(AllowEmptyStrings=false, ErrorMessage="Please enter a Warranty Expiration")]
        [DisplayName("Warranty Expiration")]
        public virtual DateTime WarrantyExpiration { get; set; }

        public virtual ICollection<User> UsedBy { get; set; }
        public virtual ICollection<NetworkAddress> NetworkAddresses { get; set; }
        public virtual ICollection<SoftwareLicense> SoftwareLicenses { get; set; }

        public Equipment()
        {
            //UsedBy = new List<User>();
            //NetworkAddresses = new List<NetworkAddress>();
            //SoftwareLicenses = new List<SoftwareLicense>();
        }
    }

    public enum UsageCategory : int
    {
        Students = 0,
        Faculty = 1
    }
}
