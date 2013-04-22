using Emu.Common;
using Emu.DataLogic;
using Emu.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Emu.Web.Controllers
{
    public class UsersController : Controller
    {
        #region Properties

        public IUsersManager Manager { get; set; }

        User DefaultUser 
        { 
            get 
            {
                return new User 
                { 
                    UserName = "", 
                    Type = UserType.BasicUser 
                };
            } 
        }

        #endregion

        #region Constructor

        public UsersController()
        {
            Manager = new UsersControl();
        }

        #endregion

        #region Method
        
        //
        // GET: /Users/

        public ActionResult Index()
        {
            var model = new UsersModel
            {
                Users = Manager.Get()
            };
            return View(model);
        }

        //
        // GET: /Users/Details/5

        public ActionResult Details(int id)
        {
            var model = Manager.Get( id );
            return View( model );
        }

        //
        // GET: /Users/Create

        public ActionResult Create()
        {
            var model = DefaultUser;

            return View( model );
        }

        //
        // POST: /Users/Create

        [HttpPost]
        public ActionResult Create(User user)
        {
            try
            {
                if( ModelState.IsValid )
                {
                    Manager.Create( user );
                    return RedirectToAction( "Index" );
                }
                else
                {
                    var model = DefaultUser;
                    return View( model );
                }
            }
            catch
            {
                var model = DefaultUser;
                return View( model );
            }
        }

        //
        // GET: /Users/Edit/5

        public ActionResult Edit(int id)
        {
            var model = Manager.Get( id );
            return View( model );
        }

        //
        // POST: /Users/Edit/5

        [HttpPost]
        public ActionResult Edit(User user)
        {
            try
            {
                if( ModelState.IsValid )
                {
                    Manager.Update( user );
                    return RedirectToAction( "Index" );
                }
                else
                {
                    return View();
                }
                
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /Users/Delete/5

        //public ActionResult Delete(int id)
        //{
        //    return View();
        //}

        //
        // POST: /Users/Delete/5

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
