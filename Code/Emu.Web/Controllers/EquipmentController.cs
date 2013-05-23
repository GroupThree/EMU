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
    public class EquipmentController : Controller
    {
        private EmuDb db = new EmuDb();

        //
        // GET: /Equipment/

        public ActionResult Index()
        {
            #region Authorization
            if( Authentication.IsAdmin == false )
            {
                return RedirectToAction( "Login", "Users" );
            }
            #endregion

            return View(db.Equipments.ToList());
        }

        //
        // GET: /Equipment/Details/5

        public ActionResult Details(int id = 0)
        {
            #region Authorization
            if( Authentication.IsAdmin == false )
            {
                return RedirectToAction( "Login", "Users" );
            }
            #endregion

            Equipment equipment = db.Equipments.Find(id);
            if (equipment == null)
            {
                return HttpNotFound();
            }
            return View(equipment);
        }

        //
        // GET: /Equipment/Create

        public ActionResult Create()
        {
            #region Authorization
            if( Authentication.IsAdmin == false )
            {
                return RedirectToAction( "Login", "Users" );
            }
            #endregion

            return View();
        }

        //
        // POST: /Equipment/Create

        [HttpPost]
        public ActionResult Create(Equipment equipment)
        {
            #region Authorization
            if( Authentication.IsAdmin == false )
            {
                return RedirectToAction( "Login", "Users" );
            }
            #endregion

            if (ModelState.IsValid)
            {
                db.Equipments.Add(equipment);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(equipment);
        }

        //
        // GET: /Equipment/Edit/5

        public ActionResult Edit(int id = 0)
        {
            #region Authorization
            if( Authentication.IsAdmin == false )
            {
                return RedirectToAction( "Login", "Users" );
            }
            #endregion

            Equipment equipment = db.Equipments.Find(id);
            if (equipment == null)
            {
                return HttpNotFound();
            }
            return View(equipment);
        }

        //
        // POST: /Equipment/Edit/5

        [HttpPost]
        public ActionResult Edit(Equipment equipment)
        {
            #region Authorization
            if( Authentication.IsAdmin == false )
            {
                return RedirectToAction( "Login", "Users" );
            }
            #endregion

            if (ModelState.IsValid)
            {
                db.Entry(equipment).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(equipment);
        }

        //
        // GET: /Equipment/Delete/5

        public ActionResult Delete(int id = 0)
        {
            #region Authorization
            if( Authentication.IsAdmin == false )
            {
                return RedirectToAction( "Login", "Users" );
            }
            #endregion

            Equipment equipment = db.Equipments.Find(id);
            if (equipment == null)
            {
                return HttpNotFound();
            }
            return View(equipment);
        }

        //
        // POST: /Equipment/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            #region Authorization
            if( Authentication.IsAdmin == false )
            {
                return RedirectToAction( "Login", "Users" );
            }
            #endregion

            Equipment equipment = db.Equipments.Find(id);
            db.Equipments.Remove(equipment);
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