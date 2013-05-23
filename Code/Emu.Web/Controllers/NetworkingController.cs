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
    public class NetworkingController : Controller
    {
        private EmuDb db = new EmuDb();

        //
        // GET: /Networking/

        public ActionResult Index()
        {
            #region Authorization
            if( Authentication.IsAdmin == false )
            {
                return RedirectToAction( "Login", "Users" );
            }
            #endregion

            return View(db.NetworkAddresses.ToList());
        }

        //
        // GET: /Networking/Details/5

        public ActionResult Details(int id = 0)
        {
            #region Authorization
            if( Authentication.IsAdmin == false )
            {
                return RedirectToAction( "Login", "Users" );
            }
            #endregion

            NetworkAddress networkaddress = db.NetworkAddresses.Find(id);
            if (networkaddress == null)
            {
                return HttpNotFound();
            }
            return View(networkaddress);
        }

        //
        // GET: /Networking/Create

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
        // POST: /Networking/Create

        [HttpPost]
        public ActionResult Create(NetworkAddress networkaddress)
        {
            #region Authorization
            if( Authentication.IsAdmin == false )
            {
                return RedirectToAction( "Login", "Users" );
            }
            #endregion

            if (ModelState.IsValid)
            {
                db.NetworkAddresses.Add(networkaddress);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(networkaddress);
        }

        //
        // GET: /Networking/Edit/5

        public ActionResult Edit(int id = 0)
        {
            #region Authorization
            if( Authentication.IsAdmin == false )
            {
                return RedirectToAction( "Login", "Users" );
            }
            #endregion

            NetworkAddress networkaddress = db.NetworkAddresses.Find(id);
            if (networkaddress == null)
            {
                return HttpNotFound();
            }
            return View(networkaddress);
        }

        //
        // POST: /Networking/Edit/5

        [HttpPost]
        public ActionResult Edit(NetworkAddress networkaddress)
        {
            #region Authorization
            if( Authentication.IsAdmin == false )
            {
                return RedirectToAction( "Login", "Users" );
            }
            #endregion

            if (ModelState.IsValid)
            {
                db.Entry(networkaddress).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(networkaddress);
        }

        //
        // GET: /Networking/Delete/5

        public ActionResult Delete(int id = 0)
        {
            #region Authorization
            if( Authentication.IsAdmin == false )
            {
                return RedirectToAction( "Login", "Users" );
            }
            #endregion

            NetworkAddress networkaddress = db.NetworkAddresses.Find(id);
            if (networkaddress == null)
            {
                return HttpNotFound();
            }
            return View(networkaddress);
        }

        //
        // POST: /Networking/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            #region Authorization
            if( Authentication.IsAdmin == false )
            {
                return RedirectToAction( "Login", "Users" );
            }
            #endregion

            NetworkAddress networkaddress = db.NetworkAddresses.Find(id);
            db.NetworkAddresses.Remove(networkaddress);
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