using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Emu.Common
{
    public interface IMaintenanceManager
    {
        List<Ticket> Get();
        Ticket Get(int id);
        void Create( Ticket ticket );
        void Update( Ticket ticket );
    }
}
