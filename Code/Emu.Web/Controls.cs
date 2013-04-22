using Emu.Common;
using Emu.DataLogic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Emu.Web
{
    public static class Controls
    {
        static IEquipmentControl equipmentControl;
        public static IEquipmentControl EquipmentControl
        {
            get
            {
                return equipmentControl ?? ( equipmentControl = new EquipmentControl() );
            }
        }

        static ILicensesControl licensesControl;
        public static ILicensesControl LicensesControl
        {
            get
            {
                return licensesControl ?? ( licensesControl = new LicensesControl() );
            }
        }

        static IMaintenanceControl maintenanceControl;
        public static IMaintenanceControl MaintenanceControl
        {
            get
            {
                return maintenanceControl ?? ( maintenanceControl = new MaintenanceControl() );
            }      
        }

        static INetworkingControl networkingControl;
        public static INetworkingControl NetworkingControl
        {
            get
            {
                return networkingControl ?? ( networkingControl = new NetworkingControl() );
            }
        }

        static ISoftwareControl softwareControl;
        public static ISoftwareControl SoftwareControl
        {
            get
            {
                return softwareControl ?? ( softwareControl = new SoftwareControl() );
            }
        }

        static IUsersControl usersControl;
        public static IUsersControl UsersControl
        {
            get
            {
                return usersControl ?? ( usersControl = new UsersControl() );
            }
        }
    }
}