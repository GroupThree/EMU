using Emu.Common;
using Emu.DataLogic;
using Emu.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Emu.Web.Controllers
{
    public class LicensesController : Controller
    {
        #region Properties

        ILicensesControl Control { get; set; }
        
        #endregion

        #region Constructor

        public LicensesController()
        {
            Control = Controls.LicensesControl;
        }

        #endregion

        #region Methods

        //
        // GET: /Licenses/

        public ActionResult Index()
        {
            var model = new LicensesModel
            {
                Licenses = Control.Get()
            };
            return View(model);
        }

        //
        // GET: /Licenses/Details/5

        public ActionResult Details(int id)
        {
            var model = Control.Get( id );
            if( model == null )
            {
                return HttpNotFound();
            }
            else
            { 
                return View(model);
            }
        }

        //
        // GET: /Licenses/Create

        public ActionResult Create()
        {
            var model = new License
            {
                Software = new Software { BarCode = 1 }
            };
            return View( model );
        }

        //
        // POST: /Licenses/Create

        [HttpPost]
        public ActionResult Create(FormCollection formValues)
        {
            var license = new License
            {
                LicenseKey = formValues[ "LicenseKey" ].ToString(),
                ExpirationDate = DateTime.Parse( formValues[ "ExpirationDate" ].ToString() ),
                Software = new Software
                {
                    BarCode = int.Parse( formValues[ "Software.BarCode" ].ToString() )
                }
            };
            try
            {
                Control.Create( license );

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /Licenses/Edit/5

        public ActionResult Edit(int id)
        {
            var model = Control.Get( id );
            return View( model );
        }

        //
        // POST: /Licenses/Edit/5

        [HttpPost]
        public ActionResult Edit(int id, License license)
        {
            try
            {
                Control.Update( license );

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /Licenses/Delete/5

        //public ActionResult Delete(int id)
        //{
        //    return View();
        //}

        //
        // POST: /Licenses/Delete/5

        //[HttpPost]
        //public ActionResult Delete(int id, FormCollection collection)
        //{
        //    try
        //    {
        //        // TODO: Add delete logic here

        //        return RedirectToAction("Index");
        //    }
        //    catch
        //    {
        //        return View();
        //    }
        //}

        #endregion
    }
}
