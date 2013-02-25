using Emu.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Emu.Web.Controllers
{
    public class MaintenanceController : Controller
    {
        //
        // GET: /Maintenance/

        public ActionResult Index()
        {
            var model = new MaintenanceModel();
            return View(model);
        }

        //
        // GET: /Maintenance/Details/5

        public ActionResult Details(int id)
        {
            var model = new MaintenanceModel()
                .Tickets
                .First( ticket => ticket.ID == id );

            return View( model );
        }

        //
        // GET: /Maintenance/Create

        public ActionResult Create()
        {
            return View("Details");
        }

        //
        // POST: /Maintenance/Create

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
        // GET: /Maintenance/Edit/5

        public ActionResult Edit(int id)
        {
            var model = new MaintenanceModel()
                .Tickets
                .First( ticket => ticket.ID == id );

            return View( model );
        }

        //
        // POST: /Maintenance/Edit/5

        //[HttpPost]
        //public ActionResult Edit(int id, FormCollection collection)
        //{
        //    try
        //    {
        //        // TODO: Add update logic here

        //        return RedirectToAction("Index");
        //    }
        //    catch
        //    {
        //        return View();
        //    }
        //}

        ////
        //// GET: /Maintenance/Delete/5

        //public ActionResult Delete(int id)
        //{
        //    return View();
        //}

        //
        // POST: /Maintenance/Delete/5

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
    }
}
