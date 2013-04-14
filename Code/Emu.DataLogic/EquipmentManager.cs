using Emu.Common;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Emu.Logic
{
    public class EquipmentManager : IEquipmentManager
    {
        #region Properties

        MySqlConnection DB { get; set; }

        #endregion
        #region Constructor

        public EquipmentManager()
        {
            DB = new MySqlConnection( "connection_string" ); 
        }

        #endregion
        #region Methods

        public List<Equipment> GetEquipment()
        {
            return new List<Equipment>();
        }

        public Equipment GetEquipment( int barcode )
        {
            if ( barcode.Positive() == false )
            {
                throw new ArgumentException( "Barcode argument must be a positive integer.", "barcode" );
            }


            return null;
        }

        public void CreateEquipment( Equipment equipment )
        {
            if ( equipment == null )
            {
                throw new ArgumentException( "Equipment argument must not be null.", "equipment" );
            }
            if ( equipment.BarCode.Positive() == false )
            {
                throw new ArgumentException( "Equipment barcode must be a positive integer.", "barcode" );
            }
        }

        public void UpdateEquipment( Equipment equipment )
        {
            if ( equipment == null )
            {
                throw new ArgumentException( "Equipment argument must not be null.", "equipment" );
            }
            if ( equipment.BarCode.Positive() == false )
            {
                throw new ArgumentException( "Equipment barcode must be a positive integer.", "barcode" );
            }
        }

        #endregion
    }
}
