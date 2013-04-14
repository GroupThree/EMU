using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Emu.Common
{
    public interface IUsersManager
    {
        List<User> GetUsers();
        User GetUser( int id );
        void CreateUser( User user );
        void UpdateUser( User user );
        User Authenticate( string username, string password );
    }
}
