using Emu.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Emu.Web.Models
{
    public class LicensesModel
    {
        public List<License> Licenses { get; set; }
    }

    public class LicensesEditModel
    {
        public License License { get; set; }
        public List<SelectListItem> Software { get; set; }
    }
}