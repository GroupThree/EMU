using Emu.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Emu.Web.Controllers
{
    public class EquipmentController : Controller
    {
        //
        // GET: /Equipment/

        public ActionResult Index()
        {
            var model = new EquipmentModel();
            return View(model);
        }

        //
        // GET: /Equipment/Details/5

        public ActionResult Details(int id)
        {
            var model = new EquipmentModel()
                        .Equipment
                        .First( equipment => equipment.BarCode == id );

            return View(model);
        }

        //
        // GET: /Equipment/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Equipment/Create

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
        // GET: /Equipment/Edit/5

        public ActionResult Edit(int id)
        {
            var model = new EquipmentModel()
                        .Equipment
                        .First( equipment => equipment.BarCode == id );

            return View(model);
        }

        //
        // POST: /Equipment/Edit/5

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
        // GET: /Equipment/Delete/5

        //public ActionResult Delete(int id)
        //{
        //    return View();
        //}

        //
        // POST: /Equipment/Delete/5

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
