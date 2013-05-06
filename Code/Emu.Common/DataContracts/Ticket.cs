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
    public class Ticket
    {
        [Key]
        [HiddenInput(DisplayValue = false)]
        public virtual int TicketID { get; set; }
        public virtual int RequestorId { get; set; }
        public virtual User Requestor { get; set; }
        public virtual int AssignedToId { get; set; }
        public virtual User AssignedTo { get; set; }
        public virtual TicketType Type { get; set; }
        public virtual TicketPiority Priority { get; set; }
        [Required(AllowEmptyStrings=false, ErrorMessage="Please enter a ticket description")]
        public virtual string TicketDescription { get; set; }
        [Required(AllowEmptyStrings=false, ErrorMessage="Please enter a ticket created date")]
        [DataType(DataType.Date)]
        public virtual DateTime TicketCreated { get; set; }
        //[Required(AllowEmptyStrings=true, ErrorMessage="Please enter a ticket closed date")]
        [DataType(DataType.Date)]
        public virtual DateTime? TicketClosed { get; set; }
    }

    public enum TicketType : int
    {
        AutomaticallyScheduled = 0,
        UserRequested = 1
    }

    public enum TicketPiority : int
    {
        Low = 1,
        Medium = 2,
        High = 3
    }
}
