using Emu.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace Emu.Web.Models
{
    public class NetworkingModel
    {
        public List<NetworkAddress> Addresses { get; set; }
    }

    public class NetworkingEditModel
    {
        public NetworkAddress Address { get; set; }
        public List<SelectListItem> AvailableEquipment { get; set; }
    }
}