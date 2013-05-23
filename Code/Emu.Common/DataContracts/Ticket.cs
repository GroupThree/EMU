using System;
using System.Collections.Generic;
using System.ComponentModel;
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
        [HiddenInput(DisplayValue=false)]
        public virtual int RequestorId { get; set; }
        [DisplayName("Requestor")]
        public virtual User Requestor { get; set; }
        [HiddenInput(DisplayValue = false)]
        public virtual int AssignedToId { get; set; }
        [DisplayName("Assigned To")]
        public virtual User AssignedTo { get; set; }
        [DisplayName("Type")]
        public virtual TicketType Type { get; set; }
        [DisplayName("Priority")]
        public virtual TicketPiority Priority { get; set; }
        [Required(AllowEmptyStrings=false, ErrorMessage="Please enter a ticket description")]
        [DisplayName("Description")]
        [DataType(DataType.MultilineText)]
        public virtual string TicketDescription { get; set; }
        [Required(AllowEmptyStrings=false, ErrorMessage="Please enter a ticket created date")]
        [DataType(DataType.Date)]
        [DisplayName("Created")]
        public virtual DateTime TicketCreated { get; set; }
        [DisplayName("Closed")]
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
        Low = 0,
        Medium = 1,
        High = 2
    }
}
