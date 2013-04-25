using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Emu.Common
{
    public class Equipment
    {
        [Required]
        public int BarCode { get; set; }
        [Required]
        public string SerialNumber { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public string Location { get; set; }
        [Required, DataType(DataType.Date)]
        public DateTime WarrantyExpiration { get; set; }

        public User UsedBy { get; set; }
    }
}
