using Emu.Common;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Emu.DataLogic
{
    public class MaintenanceManager : IMaintenanceManager
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

        public MaintenanceManager()
        {
            Connection = new MySqlConnection( "connection_string" );
        }

        #endregion
        #region Methods
        
        public List<Ticket> GetTickets()
        {
            var results = new List<Ticket>();

            return results;
        }

        public Ticket GetTicket(int id)
        {
            #region Validate Arguments

            #endregion

            Ticket result = null;
            
            return result;
        }

        public void CreateTicket( Ticket ticket )
        {
            #region Validate Arguments

            #endregion

        }

        public void UpdateTicket( Ticket ticket )
        {
            #region Validate Arguments

            #endregion

        }

        #endregion
    }
}
