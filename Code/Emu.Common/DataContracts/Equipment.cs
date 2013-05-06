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
        public virtual int Id { get; set; }
        public virtual int BarCode { get; set; }
        public virtual string SerialNumber { get; set; }
        public virtual string EDescription { get; set; }
        public virtual UsageCategory Category { get; set; }
        public virtual string Location { get; set; }
        public virtual DateTime WarrantyExpiration { get; set; }

        public virtual ICollection<User> UsedBy { get; set; }
        public virtual ICollection<Software> InstalledSoftware { get; set; }
    }

    public enum UsageCategory : int
    {
        Students = 0,
        Faculty = 1
    }
}
