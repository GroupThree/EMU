using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Emu.Common
{
    public class User
    {
        public int ID { get; set; }
        public UserType Type { get; set; }
        public string UserName { get; set; }

        List<Equipment> Equipment { get; set; }

        public User()
        {
            Equipment = new List<Equipment>();
        }
    }

    public enum UserType : int
    {
       BasicUser = 0,
       AdminUser = 1
    }
}
