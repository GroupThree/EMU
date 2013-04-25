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
    public class SoftwareController : Controller
    {
        #region Properties

        public ISoftwareControl Control { get; set; }

        #endregion

        #region Constructor

        public SoftwareController()
        {
            Control = Controls.SoftwareControl;
        }

        #endregion

        #region Methods
        
        //
        // GET: /Software/

        public ActionResult Index()
        {
            #region Authorization
            if( Authentication.IsAdmin == false )
            {
                return RedirectToAction("Index", "Home");
            }
            #endregion

            var model = new SoftwareModel
            {
                Software = Control.Get()
            };
            return View( model );
        }

        //
        // GET: /Software/Details/5

        public ActionResult Details(int id /* barcode */)
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

            return View(model);
        }

        //
        // GET: /Software/Create

        public ActionResult Create()
        {
            #region Authorization
            if( Authentication.IsAdmin == false )
            {
                return RedirectToAction("Index", "Home");
            }
            #endregion

            return View();
        }

        //
        // POST: /Software/Create

        [HttpPost]
        public ActionResult Create(Software software)
        {
            #region Authorization
            if( Authentication.IsAdmin == false )
            {
                return RedirectToAction("Index", "Home");
            }
            #endregion

            try
            {
                Control.Create( software );

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /Software/Edit/5

        public ActionResult Edit(int id /* barcode */)
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
            return View(model);
        }

        //
        // POST: /Software/Edit/5

        [HttpPost]
        public ActionResult Edit(int id /* barcode */, Software software)
        {
            #region Authorization
            if( Authentication.IsAdmin == false )
            {
                return RedirectToAction("Index", "Home");
            }
            #endregion

            try
            {
                Control.Update( software );

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /Software/Delete/5

        //public ActionResult Delete(int id)
        //{
        //    return View();
        //}

        //
        // POST: /Software/Delete/5

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
