using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Emu.Common
{
    public class User
    {
        [Key]
        [HiddenInput(DisplayValue = false)]
        public virtual int UserId { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "Please enter a username")]
        public virtual string UserName { get; set; }
        [Required(AllowEmptyStrings=false, ErrorMessage="Please enter a password")]
        [DataType(DataType.Password)]
        public virtual string Password { get; set; }
        public virtual UserType UserType { get; set; }

        public ICollection<Equipment> Equipments { get; set; }
        public virtual ICollection<Ticket> RequestedTickets { get; set; }
        public virtual ICollection<Ticket> AssignedTickets { get; set; }

        public User()
        {
            Equipments = new List<Equipment>();
            RequestedTickets = new List<Ticket>();
            AssignedTickets = new List<Ticket>();
        }
    }

    public enum UserType : int
    {
        Basic = 0,
        Admin = 1        
    }
}
