using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Emu.Common;

namespace Emu.Web.Controllers
{
    public class LicensesController : Controller
    {
        private EmuDb db = new EmuDb();

        SelectList AvailableSoftware
        {
            get { return new SelectList(db.Softwares, "SoftwareBarCode", "SoftwareDescription"); }
        }

        //
        // GET: /Licenses/

        public ActionResult Index()
        {
            return View(db.Licenses.ToList());
        }

        //
        // GET: /Licenses/Details/5

        public ActionResult Details(int id = 0)
        {
            SoftwareLicense softwarelicense = db.Licenses.Find(id);
            if (softwarelicense == null)
            {
                return HttpNotFound();
            }
            return View(softwarelicense);
        }

        //
        // GET: /Licenses/Create

        public ActionResult Create()
        {
            ViewBag.Software = db.Softwares;
            return View();
        }

        //
        // POST: /Licenses/Create

        [HttpPost]
        public ActionResult Create(SoftwareLicense softwarelicense)
        {
            if (ModelState.IsValid)
            {
                db.Licenses.Add(softwarelicense);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(softwarelicense);
        }

        //
        // GET: /Licenses/Edit/5

        public ActionResult Edit(int id = 0)
        {
            SoftwareLicense softwarelicense = db.Licenses.Find(id);
            if (softwarelicense == null)
            {
                return HttpNotFound();
            }
            return View(softwarelicense);
        }

        //
        // POST: /Licenses/Edit/5

        [HttpPost]
        public ActionResult Edit(SoftwareLicense softwarelicense)
        {
            if (ModelState.IsValid)
            {
                db.Entry(softwarelicense).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(softwarelicense);
        }

        //
        // GET: /Licenses/Delete/5

        public ActionResult Delete(int id = 0)
        {
            SoftwareLicense softwarelicense = db.Licenses.Find(id);
            if (softwarelicense == null)
            {
                return HttpNotFound();
            }
            return View(softwarelicense);
        }

        //
        // POST: /Licenses/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            SoftwareLicense softwarelicense = db.Licenses.Find(id);
            db.Licenses.Remove(softwarelicense);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}