using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Emu.Common
{
    public interface IExampleLogic
    {
        ExampleUser FindUser( Guid userID );
        List<ExampleUser> ActiveUsers();
    }
}
