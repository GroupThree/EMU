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

        public IUsersControl Control { get; set; }

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
            Control = Controls.UsersControl;
        }

        #endregion

        #region Method
        
        //
        // GET: /Users/

        public ActionResult Index()
        {
            #region Authorization
            if( Authentication.IsAdmin == false )
            {
                return RedirectToAction("Index", "Home");
            }
            #endregion
            
            var model = new UsersModel
            {
                Users = Control.Get()
            };
            return View(model);
        }

        //
        // GET: /Users/Details/5

        public ActionResult Details(int id)
        {
            #region Authorization
            if( Authentication.IsAdmin == false )
            {
                return RedirectToAction("Index", "Home");
            }
            #endregion

            var model = Control.Get( id );
            return View( model );
        }

        //
        // GET: /Users/Create

        public ActionResult Create()
        {
            #region Authorization
            if( Authentication.IsAdmin == false )
            {
                return RedirectToAction("Index", "Home");
            }
            #endregion
            var model = DefaultUser;
            return View( model );
        }

        //
        // POST: /Users/Create

        [HttpPost]
        public ActionResult Create(User user)
        {
            #region Authorization
            if( Authentication.IsAdmin == false )
            {
                return RedirectToAction("Index", "Home");
            }
            #endregion

            try
            {
                if( ModelState.IsValid )
                {
                    Control.Create( user );
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
            #region Authorization
            if( Authentication.IsAdmin == false )
            {
                return RedirectToAction("Index", "Home");
            }
            #endregion

            var model = Control.Get( id );
            if( model == null )
            {
                return HttpNotFound();
            }
            return View( model );
        }

        //
        // POST: /Users/Edit/5

        [HttpPost]
        public ActionResult Edit(User user)
        {
            #region Authorization
            if( Authentication.IsAdmin == false )
            {
                return RedirectToAction("Index", "Home");
            }
            #endregion

            try
            {
                if( ModelState.IsValid )
                {
                    try
                    {
                        Control.Update(user);
                    }
                    catch( Exception ex )
                    {
                        ViewBag.Error = ex.Message;
                        return View(user);
                    }
                    return RedirectToAction( "Index" );
                }
                else
                {
                    return View(user);
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
