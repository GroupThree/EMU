using Emu.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Emu.Web.Models
{
    public class SoftwareModels
    {
        List<Software> Software { get; set; }

        public SoftwareModels()
        {
            Software = Mockup.Data.Software;
        }
    }
}