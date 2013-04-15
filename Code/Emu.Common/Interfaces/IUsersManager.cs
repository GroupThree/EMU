using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Emu.Common
{
    public interface IUsersManager
    {
        List<User> Get();
        User Get( int id );
        void Create( User user );
        void Update( User user );
        User Authenticate( string username, string password );
    }
}
