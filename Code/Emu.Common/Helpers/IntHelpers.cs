using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Emu.Common
{
    public static class IntHelpers
    {

        public static bool IsPositive( this int This )
        {
            return This > 0;
        }
    }
}
