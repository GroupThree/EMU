using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Emu.Common
{
    public class User
    {
        public Guid ID { get; set; }
        public UserType Type { get; set; }
        public string UserName { get; set; }
        public bool Active { get; set; }
    }

    public enum UserType : int
    {
       Staff = 0,
       Admin = 1
    }
}
