using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Emu.Common
{
    public class User
    {
        public virtual int Id { get; set; }
        public virtual string UserName { get; set; }
        public virtual string Password { get; set; }
        public virtual UserType UType { get; set; }
    }

    public enum UserType : int
    {
        Basic = 0,
        Admin = 1        
    }
}
