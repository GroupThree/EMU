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
            var tickets = db.Tickets.Include(t => t.Requestor).Include(t => t.AssignedTo);
            return View(tickets.ToList());
        }

        //
        // GET: /Maintenance/Details/5

        public ActionResult Details(int id = 0)
        {
            Ticket ticket = db.Tickets.Find(id);
            if (ticket == null)
            {
                return HttpNotFound();
            }
            return View(ticket);
        }

        //
        // GET: /Maintenance/Create

        public ActionResult Create()
        {
            ViewBag.RequestorId = new SelectList(db.Users, "UserId", "UserName");
            ViewBag.AssignedToId = new SelectList(db.Users, "UserId", "UserName");
            return View();
        }

        //
        // POST: /Maintenance/Create

        [HttpPost]
        public ActionResult Create(Ticket ticket)
        {
            if (ModelState.IsValid)
            {
                db.Tickets.Add(ticket);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.RequestorId = new SelectList(db.Users, "UserId", "UserName", ticket.RequestorId);
            ViewBag.AssignedToId = new SelectList(db.Users, "UserId", "UserName", ticket.AssignedToId);
            return View(ticket);
        }

        //
        // GET: /Maintenance/Edit/5

        public ActionResult Edit(int id = 0)
        {
            Ticket ticket = db.Tickets.Find(id);
            if (ticket == null)
            {
                return HttpNotFound();
            }
            ViewBag.RequestorId = new SelectList(db.Users, "UserId", "UserName", ticket.RequestorId);
            ViewBag.AssignedToId = new SelectList(db.Users, "UserId", "UserName", ticket.AssignedToId);
            return View(ticket);
        }

        //
        // POST: /Maintenance/Edit/5

        [HttpPost]
        public ActionResult Edit(Ticket ticket)
        {
            if (ModelState.IsValid)
            {
                db.Entry(ticket).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.RequestorId = new SelectList(db.Users, "UserId", "UserName", ticket.RequestorId);
            ViewBag.AssignedToId = new SelectList(db.Users, "UserId", "UserName", ticket.AssignedToId);
            return View(ticket);
        }

        //
        // GET: /Maintenance/Delete/5

        public ActionResult Delete(int id = 0)
        {
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