using Emu.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Emu.Web.Models
{
    public class LicensesModel
    {
        public List<License> Licenses { get; set; }
        public List<Software> Software { get; set; }
    }
}