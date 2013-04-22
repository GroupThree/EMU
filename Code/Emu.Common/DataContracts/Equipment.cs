using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Emu.Common
{
    public class Equipment
    {
        public int BarCode { get; set; }
        public string SerialNumber { get; set; }
        public string Description { get; set; }
        public string Location { get; set; }
        public DateTime WarrantyExpiration { get; set; }

        public User UsedBy { get; set; }
        public List<License> Licenses { get; set; }
        public List<Ticket> MaintenanceTickets { get; set; }
        public List<NetworkAddress> NetworkAddresses { get; set; }
        public List<Software> InstalledSoftware
        {
            get
            {
                return Licenses.Select( lic => lic.Software ).ToList();
            }
        }

        public Equipment()
        {
            Licenses = new List<License>();
            MaintenanceTickets = new List<Ticket>();
            NetworkAddresses = new List<NetworkAddress>();
        }
    }
}
