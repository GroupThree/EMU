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
    public class MaintenanceController : Controller
    {
        #region Properties

        IMaintenanceControl Control { get; set; }

        #endregion

        #region Constructor

        public MaintenanceController()
        {
            Control = Controls.MaintenanceControl;
        }

        #endregion

        #region Methods
        
        //
        // GET: /Maintenance/

        public ActionResult Index()
        {
            #region Authorization
            if( Authentication.IsAdmin == false )
            {
                return RedirectToAction("Index", "Home");
            }
            #endregion


            var model = new MaintenanceModel
            {
                Tickets = Control.Get()
            };
            return View(model);
        }

        //
        // GET: /Maintenance/Details/5

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

            return View( model );
        }

        //
        // GET: /Maintenance/Create

        public ActionResult Create()
        {
            #region Authorization
            if( Authentication.IsAuthenticated == false )
            {
                return RedirectToAction("Index", "Home");
            }
            #endregion
            var model = new MaintenanceCreateModel
            {
                Ticket = new Ticket(),
                AvailableEquipment = Controls.EquipmentControl.Get().Select( e => new SelectListItem { Text = e.Description, Value = e.BarCode.ToString() } ).ToList()
            };
            return View( model );
        }

        //
        // POST: /Maintenance/Create

        [HttpPost]
        public ActionResult Create(FormCollection formValues)
        {
            #region Authorization
            if( Authentication.IsAuthenticated == false )
            {
                return RedirectToAction("Index", "Home");
            }
            #endregion

            var userInfo = ( HttpContext.Session[ "UserInfo" ] as User ) ?? new User { ID = 1 };
            var ticket = new Ticket 
            {
                Description = formValues["Ticket.Description"],
                Type = TicketType.UserRequested,
                DateCreated = DateTime.Now,
                Requestor = new Common.User
                {
                    ID = userInfo.ID
                },
                Equipment = new Equipment 
                {
                    BarCode = int.Parse(formValues[ "Equipment.BarCode" ] )
                }
            };

            try
            {
                Control.Create( ticket );

                return RedirectToAction("Index");
            }
            catch
            {
                var model = new MaintenanceCreateModel
                {
                    Ticket = ticket,
                    AvailableEquipment = Controls.EquipmentControl.Get().Select( e => new SelectListItem { Text = e.Description, Value = e.BarCode.ToString() } ).ToList()
                };
                return View( model );
            }
        }

        //
        // GET: /Maintenance/Edit/5

        public ActionResult Edit(int id)
        {
            #region Authorization
            if( Authentication.IsAdmin == false )
            {
                return RedirectToAction("Index", "Home");
            }
            #endregion

            var ticket = Control.Get( id );

            if( ticket == null )
            {
                return HttpNotFound();
            }

            var model = new MaintenanceEditModel
            {
                Ticket = ticket,
                AvailableLicense = (from license in Controls.LicensesControl.Get()
                                    where license.ExpirationDate > DateTime.Today
                                    select new SelectListItem
                                    {
                                       Text = license.Software.Description,
                                       Value = license.ID.ToString()
                                    }).ToList()
            };

            return View( model );
        }

        //
        // POST: /Maintenance/Edit/5

        [HttpPost]
        public ActionResult Edit( FormCollection formValues )
        {
            #region Authorization
            if( Authentication.IsAdmin == false )
            {
                return RedirectToAction("Index", "Home");
            }
            #endregion

            var ticket = new Ticket
            {
                ID = int.Parse( formValues[ "Ticket.ID" ] ),
                Description = formValues[ "Ticket.Description" ],
                Type = int.Parse( formValues[ "Ticket.Type" ] ).ToEnum<TicketType>(),
                DateCreated = DateTime.Parse( formValues[ "Ticket.DateCreated" ] ),
                DateClosed = DateTime.Parse( formValues[ "Ticket.DateClosed" ] ),
                Equipment = new Equipment
                {
                    BarCode = int.Parse( formValues[ "Equipment.BarCode" ] )
                },
                License = new License
                {
                    ID = int.Parse(formValues["License.ID"])
                }
            };

            try
            {
                Control.Update( ticket );

                return RedirectToAction( "Index" );
            }
            catch(Exception ex)
            {
                ViewBag.Error = ex.Message;
                var model = new MaintenanceEditModel
                {
                    Ticket = ticket,
                    AvailableLicense = ( from license in Controls.LicensesControl.Get()
                                         where license.ExpirationDate > DateTime.Today
                                         select new SelectListItem
                                         {
                                             Text = license.Software.Description,
                                             Value = license.ID.ToString()
                                         } ).ToList()
                };
                return View(model);
            }
        }

        ////
        //// GET: /Maintenance/Delete/5

        //public ActionResult Delete(int id)
        //{
        //    return View();
        //}

        //
        // POST: /Maintenance/Delete/5

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
