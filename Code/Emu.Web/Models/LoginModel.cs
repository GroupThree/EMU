using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace Emu.Web.Models
{
    public class LoginModel
    {
        [Required(AllowEmptyStrings=false, ErrorMessage = "Please enter in a username to log in")]
        public string Username { get; set; }
        [Required(AllowEmptyStrings=false, ErrorMessage = "Please enter a password to log in")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
