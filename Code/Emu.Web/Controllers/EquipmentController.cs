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
    public class EquipmentController : Controller
    {
        #region Properties

        IEquipmentControl Control { get; set; }

        #endregion

        #region Constructor

        public EquipmentController()
        {
            Control = Controls.EquipmentControl;
        }

        #endregion

        #region Methods

        public ActionResult Index()
        {
            var model = new EquipmentModel
            {
                Equipment = Control.Get()
            };
            return View(model);
        }

        //
        // GET: /Equipment/Details/5

        public ActionResult Details(int id /* barcode */)
        {
            var model = Control.Get( id );
            return View(model);
        }

        //
        // GET: /Equipment/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Equipment/Create

        [HttpPost]
        public ActionResult Create(Equipment equipment)
        {
            try
            {
                Control.Create( equipment );

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /Equipment/Edit/5

        public ActionResult Edit(int id)
        {
            var model = Control.Get( id );
            return View(model);
        }

        //
        // POST: /Equipment/Edit/5

        [HttpPost]
        public ActionResult Edit(int id, Equipment equipment)
        {
            try
            {
                Control.Update( equipment );

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /Equipment/Delete/5

        //public ActionResult Delete(int id)
        //{
        //    return View();
        //}

        //
        // POST: /Equipment/Delete/5

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
