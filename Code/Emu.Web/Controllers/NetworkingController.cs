using Emu.Common;
using Emu.Logic;
using Emu.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Emu.Web.Controllers
{
    public class NetworkingController : Controller
    {
        #region Properties

        public INetworkingManager Manager { get; set; }

        #endregion

        #region Constructor

        public NetworkingController()
        {
            Manager = new NetworkingManager();
        }

        #endregion

        #region Methods

        //
        // GET: /Networking/

        public ActionResult Index()
        {
            var model = new NetworkingModel();
            return View( model );
        }

        //
        // GET: /Networking/Details/5

        public ActionResult Details(int id)
        {
            var model = new NetworkingModel()
                .Addresses
                .First(address => address.ID == id );

            return View( model );
        }

        //
        // GET: /Networking/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Networking/Create

        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /Networking/Edit/5

        public ActionResult Edit(int id)
        {
            var model = new NetworkingModel()
                .Addresses
                .First( address => address.ID == id );

            return View( model );
        }

        //
        // POST: /Networking/Edit/5

        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /Networking/Delete/5

        //public ActionResult Delete(int id)
        //{
        //    return View();
        //}

        //
        // POST: /Networking/Delete/5

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
