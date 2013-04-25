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
        public int ID { get; set; }
        public Software Software { get; set; }
        [Required]
        public string LicenseKey { get; set; }
        [Required,DataType(DataType.Date)]
        public DateTime ExpirationDate { get; set; }
    }
}
