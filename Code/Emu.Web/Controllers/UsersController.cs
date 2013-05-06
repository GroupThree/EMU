using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Emu.Common;
using Emu.Web.Models;

namespace Emu.Web.Controllers
{
    public class UsersController : Controller
    {
        private EmuDb db = new EmuDb();

        //
        // GET: /Users/

        public ActionResult Index()
        {
            #region Authorization
            if( Authentication.IsAdmin == false )
            {
                return RedirectToAction( "Users", "Login" );
            }
            #endregion

            return View(db.Users.ToList());
        }

        public ActionResult Login()
        {
            var model = new LoginModel();
            return View( model );
        }

        [HttpPost]
        public ActionResult Login( string username, string password )
        {
            Exception err = null;
            Common.User user = null;
            try
            {
                user = Authentication.AuthenticateUser( username, password );
            }
            catch( Exception e )
            {
                err = e;
            }

            var model = new LoginModel
            {
                Username = username,
                Password = password
            };


            if( user == null )
            {
                ViewBag.Error = "Username or password was invalid";

                return View( model );
            }
            else if( err != null )
            {
                ViewBag.Error = err.Message;
                return View( model );
            }
            else
            {
                return RedirectToAction( "Index", "Maintenance" );
            }
        }

        public ActionResult LogOut()
        {
            Authentication.LogOut();
            return RedirectToAction( "Login", "Home" );
        }

        //
        // GET: /Users/Details/5

        public ActionResult Details(int id = 0)
        {
            #region Authorization
            if( Authentication.IsAdmin == false )
            {
                return RedirectToAction( "Users", "Login" );
            }
            #endregion

            User user = db.Users.Find(id);
            if (user == null)
            {
                return HttpNotFound();
            }
            return View(user);
        }

        List<SelectListItem> GetUserTypeList(UserType userType)
        {
            return new List<SelectListItem>(new List<SelectListItem> 
                {
                    new SelectListItem { Value = ((int)UserType.Basic).ToString(), Text = "Basic", Selected = UserType.Basic == userType },
                    new SelectListItem { Value = ((int)UserType.Admin).ToString(), Text = "Admin", Selected = UserType.Admin == userType } 
                });
        }

        //
        // GET: /Users/Create

        public ActionResult Create()
        {
            #region Authorization
            if( Authentication.IsAdmin == false )
            {
                return RedirectToAction( "Users", "Login" );
            }
            #endregion

            ViewBag.UserType = GetUserTypeList(UserType.Basic);
            return View();
        }

        //
        // POST: /Users/Create

        [HttpPost]
        public ActionResult Create(User user)
        {
            #region Authorization
            if( Authentication.IsAdmin == false )
            {
                return RedirectToAction( "Users", "Login" );
            }
            #endregion

            if (ModelState.IsValid)
            {
                db.Users.Add(user);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.UserType = GetUserTypeList(user != null ? user.UserType : UserType.Basic);
            return View(user);
        }

        //
        // GET: /Users/Edit/5

        public ActionResult Edit(int id = 0)
        {
            #region Authorization
            if( Authentication.IsAdmin == false )
            {
                return RedirectToAction( "Users", "Login" );
            }
            #endregion

            User user = db.Users.Find(id);
            if (user == null)
            {
                return HttpNotFound();
            }

            ViewBag.UserType = ViewBag.UserType = GetUserTypeList(user != null ? user.UserType : UserType.Basic);
            return View(user);
        }

        //
        // POST: /Users/Edit/5

        [HttpPost]
        public ActionResult Edit(User user)
        {
            #region Authorization
            if( Authentication.IsAdmin == false )
            {
                return RedirectToAction( "Users", "Login" );
            }
            #endregion

            if (ModelState.IsValid)
            {
                db.Entry(user).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.UserType = GetUserTypeList(user != null ? user.UserType : UserType.Basic);
            return View(user);
        }

        //
        // GET: /Users/Delete/5

        public ActionResult Delete(int id = 0)
        {
            #region Authorization
            if( Authentication.IsAdmin == false )
            {
                return RedirectToAction( "Users", "Login" );
            }
            #endregion

            User user = db.Users.Find(id);
            if (user == null)
            {
                return HttpNotFound();
            }
            return View(user);
        }

        //
        // POST: /Users/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            #region Authorization
            if( Authentication.IsAdmin == false )
            {
                return RedirectToAction( "Users", "Login" );
            }
            #endregion

            User user = db.Users.Find(id);
            db.Users.Remove(user);
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