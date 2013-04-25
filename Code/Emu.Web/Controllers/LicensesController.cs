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
    public class LicensesController : Controller
    {
        #region Properties

        ILicensesControl Control { get; set; }
        
        #endregion

        #region Constructor

        public LicensesController()
        {
            Control = Controls.LicensesControl;
        }

        #endregion

        #region Methods

        //
        // GET: /Licenses/

        public ActionResult Index()
        {
            #region Authorization
            if( Authentication.IsAdmin == false )
            {
                return RedirectToAction("Index", "Home");
            }
            #endregion

            var model = new LicensesModel
            {
                Licenses = Control.Get()
            };
            return View(model);
        }

        //
        // GET: /Licenses/Details/5

        public ActionResult Details(int id)
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
            else
            { 
                return View(model);
            }
        }

        //
        // GET: /Licenses/Create

        public ActionResult Create()
        {
            #region Authorization
            if( Authentication.IsAdmin == false )
            {
                return RedirectToAction("Index", "Home");
            }
            #endregion

            var model = new License
            {
                Software = new Software { BarCode = 1 }
            };
            return View( model );
        }

        //
        // POST: /Licenses/Create

        [HttpPost]
        public ActionResult Create(FormCollection formValues)
        {
            #region Authorization
            if( Authentication.IsAdmin == false )
            {
                return RedirectToAction("Index", "Home");
            }
            #endregion

            var license = new License
            {
                LicenseKey = formValues[ "LicenseKey" ].ToString(),
                ExpirationDate = DateTime.Parse( formValues[ "ExpirationDate" ].ToString() ),
                Software = new Software
                {
                    BarCode = 1
                }
            };
            try
            {
                Control.Create( license );

                return RedirectToAction("Index");
            }
            catch(Exception ex)
            {
                ViewBag.Error = ex.Message;
                return View(license);
            }
        }

        //
        // GET: /Licenses/Edit/5

        public ActionResult Edit(int id)
        {
            #region Auothorization
            if( Authentication.IsAdmin == false )
            {
                return RedirectToAction("Index", "Home");
            }
            #endregion
            var model = new LicensesEditModel
            {
                License = Control.Get( id )
            };

            if( model.License == null )
            {
                return HttpNotFound();
            }

            model.Software = ( from software in Controls.SoftwareControl.Get()
                               select new SelectListItem
                               {
                                   Text = software.Description,
                                   Value = software.BarCode.ToString(),
                                   Selected = software.BarCode == model.License.Software.BarCode
                               } ).ToList();

            return View( model );
        }

        //
        // POST: /Licenses/Edit/5

        [HttpPost]
        public ActionResult Edit(FormCollection formValues)
        {
            #region Authorization
            if( Authentication.IsAdmin == false )
            {
                return RedirectToAction("Index", "Home");
            }
            #endregion

            var license = new License
            {
                ID = int.Parse(formValues["License.ID"]),
                LicenseKey = formValues["License.LicenseKey"],
                ExpirationDate = DateTime.Parse(formValues["License.ExpirationDate"]),
                Software = new Software
                {
                    BarCode = int.Parse(formValues["License.Software"])
                }
            };

            try
            {
                Control.Update( license );

                return RedirectToAction("Index");
            }
            catch
            {
                var model = new LicensesEditModel
                {
                    License = license,
                    Software = ( from software in Controls.SoftwareControl.Get()
                               select new SelectListItem
                               {
                                   Text = software.Description,
                                   Value = software.BarCode.ToString(),
                                   Selected = software.BarCode == license.Software.BarCode
                               } ).ToList()
                };
                return View();
            }
        }

        //
        // GET: /Licenses/Delete/5

        //public ActionResult Delete(int id)
        //{
        //    return View();
        //}

        //
        // POST: /Licenses/Delete/5

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
