using Emu.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Emu.Web.Controllers
{
    public class HomeController : Controller
    {
        #region Properties



        #endregion

        #region Constructor

        public HomeController()
        {

        }

        #endregion

        #region Methods

        //
        // GET: /Home/

        public ActionResult Index()
        {
            if( Authentication.IsAuthenticated == false )
            {
                return RedirectToAction( "Login", "Home" );
            }

            if( Authentication.IsAdmin == false )
            {
                return RedirectToAction( "Create", "Maintenance" );
            }
            else
            { 
                return RedirectToAction( "Index", "Maintenance" );
            }
        }


        public ActionResult Login()
        {
            var model = new LoginModel();
            return View(model);
        }

        [HttpPost]
        public ActionResult Login( string username, string password )
        {
            Exception err = null;
            Common.User user = null;
            try
            {
                user = Controls.UsersControl.Authenticate(username, password);
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
                
                return View(model);
            }
            else if( err != null )
            {
                ViewBag.Error = err.Message;
                return View(model);
            }
            else
            {
                Authentication.CurrentUser = user;
                return RedirectToAction("Index");
            }
        }

        public ActionResult LogOut()
        {
            Authentication.CurrentUser = null;
            return RedirectToAction("Login");
        }
        //
        // GET: /Home/Details/5

        //public ActionResult Details(int id)
        //{
        //    return View();
        //}

        //
        // GET: /Home/Create

        //public ActionResult Create()
        //{
        //    return View();
        //}

        //
        // POST: /Home/Create

        //[HttpPost]
        //public ActionResult Create(FormCollection collection)
        //{
        //    try
        //    {
        //        // TODO: Add insert logic here

        //        return RedirectToAction("Index");
        //    }
        //    catch
        //    {
        //        return View();
        //    }
        //}

        //
        // GET: /Home/Edit/5

        //public ActionResult Edit(int id)
        //{
        //    return View();
        //}

        //
        // POST: /Home/Edit/5

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

        //
        // GET: /Home/Delete/5

        //public ActionResult Delete(int id)
        //{
        //    return View();
        //}

        //
        // POST: /Home/Delete/5

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

        #endregion
    }
}
