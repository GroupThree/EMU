using Emu.Common;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Emu.DataLogic
{
    public class MaintenanceControl : IMaintenanceManager
    {
        #region Properties
        
        MySqlConnection Connection { get; set; }

        struct SQL
        {
            public const string GetAll = "select * from asdfasdfa";
            public const string GetByBarcode = "select * from asdfasdf where";
            public const string Create = "insert into asdfasdf() values ()";
            public const string Update = "update asdfasdf set  fdsadfds where  fdsawer";
        }

        #endregion
        #region Constructor

        public MaintenanceControl()
        {
            Connection = new MySqlConnection( "connection_string" );
        }

        #endregion
        #region Methods
        
        public List<Ticket> Get()
        {
            var results = new List<Ticket>();

            return results;
        }

        public Ticket Get(int id)
        {
            #region Validate Arguments

            #endregion

            Ticket result = null;
            
            return result;
        }

        public void Create( Ticket ticket )
        {
            #region Validate Arguments

            #endregion

        }

        public void Update( Ticket ticket )
        {
            #region Validate Arguments

            #endregion

        }

        #endregion
    }
}
