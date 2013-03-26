using Emu.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Emu.Logic
{
    public class UsersManager : IUsersManager
    {
        public List<User> GetUsers()
        {
            return new List<User>();
        }

        public User GetUser( int id )
        {
            return new User();
        }

        public void CreateUser( User user )
        {
            
        }

        public void UpdateUser( User user )
        {
            
        }
    }
}
