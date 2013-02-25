using Emu.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Emu.Web.Models
{
    public class SoftwareModel
    {
        public List<Software> Software { get; set; }

        public SoftwareModel()
        {
            Software = Mockup.Data.Software;
        }
    }
}