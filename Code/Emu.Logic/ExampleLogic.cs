using Emu.Common;
using Emu.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Emu.Logic
{
    public class ExampleLogic : IExampleLogic
    {
        ExampleUserRepository repository { get; set; }

        public ExampleLogic()
        {
            repository = new ExampleUserRepository();
        }

        public ExampleUser FindUser( Guid userID )
        {
            return repository.FindUser( userID );
        }

        public List<ExampleUser> ActiveUsers()
        {
            return repository.ActiveUsers();
        }
    }
}
