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

        ILicensesManager Manager { get; set; }
        
        #endregion

        #region Constructor

        public LicensesController()
        {
            Manager = new LicensesControl();
        }

        #endregion

        #region Methods

        //
        // GET: /Licenses/

        public ActionResult Index()
        {
            var model = new LicensesModel
            {
                Licenses = Manager.Get()
            };
            return View(model);
        }

        //
        // GET: /Licenses/Details/5

        public ActionResult Details(int id)
        {
            var model = new LicensesModel 
            {
                Licenses = new List<License>{  Manager.Get( id ) },
                Software = new List<Software>()
            };
            return View(model);
        }

        //
        // GET: /Licenses/Create

        public ActionResult Create()
        {
            var model = new LicensesModel 
            {
                // add code to get available software
                Software = new List<Software>() 
            };
            return View();
        }

        //
        // POST: /Licenses/Create

        [HttpPost]
        public ActionResult Create(License license)
        {
            try
            {
                Manager.Create( license );

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
            var model = Manager.Get( id );
            return View( model );
        }

        //
        // POST: /Licenses/Edit/5

        [HttpPost]
        public ActionResult Edit(int id, License license)
        {
            try
            {
                Manager.Update( license );

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
