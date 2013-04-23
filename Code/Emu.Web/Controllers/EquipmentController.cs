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
            if( model == null )
            {
                return HttpNotFound();
            }
            else
            { 
                return View(model);
            }
        }

        //
        // GET: /Equipment/Create

        public ActionResult Create()
        {
            var model = new Equipment { };
            return View(model);
        }

        //
        // POST: /Equipment/Create

        [HttpPost]
        public ActionResult Create(Equipment equipment)
        {
            equipment.UsedBy = new User { ID = 1 };
            try
            {
                Control.Create( equipment );

                return RedirectToAction("Index");
            }
            catch
            {
                return View(equipment);
            }
        }

        //
        // GET: /Equipment/Edit/5

        public ActionResult Edit(int id)
        {
            var equipment = Control.Get( id );
            if( equipment == null)
            {
                return HttpNotFound();
            }
            var selectList = (from user in Controls.UsersControl.Get()
                             select new SelectListItem 
                             {
                                 Text = user.UserName,
                                 Value = user.ID.ToString(),
                                 Selected = user.ID == equipment.UsedBy.ID
                             }).ToList();
            var model = new EquipmentCreateEditModel
            {
                Equipment = equipment,
                AvailableUsers = selectList
            };

            return View( model );
        }

        //
        // POST: /Equipment/Edit/5

        [HttpPost]
        public ActionResult Edit(FormCollection formValues)
        {
            var equipment = new Equipment
            {
                BarCode = int.Parse(formValues[ "Equipment.BarCode" ]),
                SerialNumber = formValues[ "Equipment.SerialNumber" ],
                Description = formValues[ "Equipment.Description" ],
                Location = formValues["Equipment.Location"],
                WarrantyExpiration = DateTime.Parse(formValues["Equipment.WarrantyExpiration"]),
                UsedBy = new User
                {
                    ID = int.Parse(formValues["UsedBy.ID"])
                }
            };
            try
            {
                Control.Update( equipment );

                return RedirectToAction("Index");
            }
            catch(Exception ex)
            {
                return View(equipment);
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
