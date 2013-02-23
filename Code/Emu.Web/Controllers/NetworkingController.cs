using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Emu.Web.Controllers
{
    public class NetworkingController : Controller
    {
        //
        // GET: /Networking/

        public ActionResult Index()
        {
            return View();
        }

        //
        // GET: /Networking/Details/5

        public ActionResult Details(int id)
        {
            return View();
        }

        //
        // GET: /Networking/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Networking/Create

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
        // GET: /Networking/Edit/5

        public ActionResult Edit(int id)
        {
            return View();
        }

        //
        // POST: /Networking/Edit/5

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
        // GET: /Networking/Delete/5

        public ActionResult Delete(int id)
        {
            return View();
        }

        //
        // POST: /Networking/Delete/5

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
