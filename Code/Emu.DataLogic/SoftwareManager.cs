﻿using Emu.Common;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Emu.DataLogic
{
    public class SoftwareManager : ISoftwareManager
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

        public SoftwareManager()
        {
            Connection = new MySqlConnection( "connection_string" ); 
        }

        #endregion
        #region Methods
        
        public List<Software> GetSoftware()
        {
            var results = new List<Software>();
            
            return results;
        }

        public Software GetSoftware( int barcode )
        {
            #region Validate Arguments

            #endregion

            Software result = null;
            
            return result;
        }

        public void CreateSoftware( Software software )
        {
            #region Validate Arguments

            #endregion

        }

        public void UpdateSoftware( Software software )
        {
            #region Validate Arguments

            #endregion

        }

        #endregion
    }
}