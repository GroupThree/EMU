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
    public class SoftwareController : Controller
    {
        #region Properties

        public ISoftwareManager Manager { get; set; }

        #endregion

        #region Constructor

        public SoftwareController()
        {
            Manager = new SoftwareManager();
        }

        #endregion

        #region Methods
        
        //
        // GET: /Software/

        public ActionResult Index()
        {
            var model = new SoftwareModel();
            return View( model );
        }

        //
        // GET: /Software/Details/5

        public ActionResult Details(int barCode)
        {
            var model = new SoftwareModel()
                        .Software
                        .First( software => software.BarCode == barCode );
            
            return View(model);
        }

        //
        // GET: /Software/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Software/Create

        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /Software/Edit/5

        public ActionResult Edit(int barCode)
        {
            var model = new SoftwareModel()
                .Software
                .First(software => software.BarCode == barCode);
            
            return View(model);
        }

        //
        // POST: /Software/Edit/5

        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /Software/Delete/5

        //public ActionResult Delete(int id)
        //{
        //    return View();
        //}

        //
        // POST: /Software/Delete/5

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
