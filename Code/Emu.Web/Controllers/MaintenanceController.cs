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
    public class MaintenanceController : Controller
    {
        private EmuDb db = new EmuDb();

        //
        // GET: /Maintenance/

        public ActionResult Index()
        {
            #region Authorization
            if( Authentication.IsAdmin == false )
            {
                return RedirectToAction( "Login", "Users" );
            }
            #endregion

            var tickets = db.Tickets.Include(t => t.Requestor).Include(t => t.AssignedTo);
            return View(tickets.ToList());
        }

        //
        // GET: /Maintenance/Details/5

        public ActionResult Details(int id = 0)
        {
            #region Authorization
            if( Authentication.IsAdmin == false )
            {
                return RedirectToAction( "Login", "Users" );
            }
            #endregion

            Ticket ticket = db.Tickets.Find(id);
            if (ticket == null)
            {
                return HttpNotFound();
            }
            return View(ticket);
        }

        //
        // GET: /Maintenance/Create

        IEnumerable<SelectListItem> AvailableRequestors(User user)
        {
            IEnumerable<SelectListItem> list = new SelectList(db.Users, "UserId", "UserName");

            if( user != null )
            {
                list = db.Users.Select( u => new SelectListItem { Selected = u.UserId == user.UserId, Value = u.UserId.ToString(), Text = u.UserName  } ).ToList();
            }

            return list;
        }

        IEnumerable<SelectListItem> AvailableAssignees( User user )
        {
            IEnumerable < SelectListItem> list = new SelectList( db.Users.Where( u => u.UserType == UserType.Admin ), "UserId", "UserName" );

            if( user != null )
            {
                list = db.Users.Where(u => u.UserType == UserType.Admin).Select( u => new SelectListItem { Selected = u.UserId == user.UserId, Value = u.UserId.ToString(), Text = u.UserName } ).ToList();
            }

            return list;
        }

        public ActionResult Create()
        {
            #region Authorization
            if( Authentication.IsAdmin == false )
            {
                return RedirectToAction( "Login", "Users" );
            }
            #endregion

            ViewBag.Priority = new List<SelectListItem>() { new SelectListItem{ Selected = false, Text = "Low ", Value = 0.ToString() }, new SelectListItem{ Selected = true, Text = "Medium", Value = 1.ToString() }, new SelectListItem{ Selected = false, Text = "High", Value = 2.ToString() } };
            ViewBag.RequestorId = AvailableRequestors(null);
            ViewBag.AssignedToId = AvailableAssignees(null);
            return View();
        }

        //
        // POST: /Maintenance/Create

        [HttpPost]
        public ActionResult Create(Ticket ticket)
        {
            #region Authorization
            if( Authentication.IsAdmin == false )
            {
                return RedirectToAction( "Login", "Users" );
            }
            #endregion

            if (ModelState.IsValid)
            {
                db.Tickets.Add(ticket);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.RequestorId = AvailableRequestors(null);
            ViewBag.AssignedToId = AvailableAssignees(null);
            return View(ticket);
        }

        //
        // GET: /Maintenance/Edit/5

        public ActionResult Edit(int id = 0)
        {
            #region Authorization
            if( Authentication.IsAdmin == false )
            {
                return RedirectToAction( "Login", "Users" );
            }
            #endregion

            Ticket ticket = db.Tickets.Find(id);
            if (ticket == null)
            {
                return HttpNotFound();
            }
            ViewBag.RequestorId = AvailableRequestors(null);
            ViewBag.AssignedToId = AvailableAssignees(null);
            return View(ticket);
        }

        //
        // POST: /Maintenance/Edit/5

        [HttpPost]
        public ActionResult Edit(Ticket ticket)
        {
            #region Authorization
            if( Authentication.IsAdmin == false )
            {
                return RedirectToAction( "Login", "Users" );
            }
            #endregion

            if (ModelState.IsValid)
            {
                db.Entry(ticket).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.RequestorId = AvailableRequestors(null);
            ViewBag.AssignedToId = AvailableAssignees(null);
            return View(ticket);
        }

        //
        // GET: /Maintenance/Delete/5

        public ActionResult Delete(int id = 0)
        {
            #region Authorization
            if( Authentication.IsAdmin == false )
            {
                return RedirectToAction( "Login", "Users" );
            }
            #endregion

            Ticket ticket = db.Tickets.Find(id);
            if (ticket == null)
            {
                return HttpNotFound();
            }
            return View(ticket);
        }

        //
        // POST: /Maintenance/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            #region Authorization
            if( Authentication.IsAdmin == false )
            {
                return RedirectToAction( "Login", "Users" );
            }
            #endregion

            Ticket ticket = db.Tickets.Find(id);
            db.Tickets.Remove(ticket);
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