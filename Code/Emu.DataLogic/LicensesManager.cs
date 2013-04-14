using Emu.Common;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Emu.DataLogic
{
    public class LicensesManager : ILicensesManager
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

        public LicensesManager()
        {
            Connection = new MySqlConnection( "connection_string" ); 
        }

        #endregion
        #region Methods

        public List<License> GetLicenses()
        {
            var results = new List<License>();
            
            return results;
        }

        public License GetLicense( int barcode )
        {
            License result = null;
            
            return result;
        }

        public void CreateLicense( License license )
        {
            #region Validate Arguments

            #endregion

        }

        public void UpdateLicense( License license )
        {
            #region Validate Arguments

            #endregion

        }

        public void CreateRelationship( License license, Equipment equipment )
        {
            #region Validate Arguments

            #endregion
        }

        #endregion
    }
}
