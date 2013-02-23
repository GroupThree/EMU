using Emu.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Emu.Web
{
    public class UsersModel
    {
        public List<User> Users { get; set; }

        public UsersModel()
        {
            Users = new List<User> 
            {
                new User{ ID = 1, UserName = "bnewton@unomaha.edu", Type = UserType.AdminUser },
                new User{ ID = 2, UserName = "abmedury@unomaha.edu", Type = UserType.AdminUser },
                new User{ ID = 3, UserName = "twbrown@unomaha.edu", Type = UserType.BasicUser },
                new User{ ID = 4, UserName = "joerter@unomaha.edu", Type = UserType.BasicUser }
            };
        }
    }
}