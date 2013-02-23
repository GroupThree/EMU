using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Emu.Web.Controllers
{
    public class LicensesController : Controller
    {
        //
        // GET: /Licenses/

        public ActionResult Index()
        {
            return View();
        }

        //
        // GET: /Licenses/Details/5

        public ActionResult Details(int id)
        {
            return View();
        }

        //
        // GET: /Licenses/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Licenses/Create

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
        // GET: /Licenses/Edit/5

        public ActionResult Edit(int id)
        {
            return View();
        }

        //
        // POST: /Licenses/Edit/5

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
        // GET: /Licenses/Delete/5

        public ActionResult Delete(int id)
        {
            return View();
        }

        //
        // POST: /Licenses/Delete/5

        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
