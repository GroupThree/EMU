﻿using Emu.Common;
using Emu.DataLogic;
using Emu.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace Emu.Web.Controllers
{
    public class NetworkingController : Controller
    {
        #region Properties

        public INetworkingControl Control { get; set; }

        #endregion

        #region Constructor

        public NetworkingController()
        {
            Control = Controls.NetworkingControl;
        }

        #endregion

        #region Methods

        //
        // GET: /Networking/

        public ActionResult Index()
        {
            var model = new NetworkingModel
            {
                Addresses = Control.Get()
            };
            return View( model );
        }

        //
        // GET: /Networking/Details/5

        public ActionResult Details(int id)
        {
            var model = Control.Get( id );
            return View( model );
        }

        //
        // GET: /Networking/Create

        public ActionResult Create()
        {
            var model = new NetworkAddress 
            {
                IP = IPAddress.None,
                InstalledOn = new Equipment
                {
                    BarCode = 1
                }
            };

            return View();
        }

        //
        // POST: /Networking/Create

        [HttpPost]
        public ActionResult Create(FormCollection formValues)
        {
            var address = new NetworkAddress
            {
                IP = IPAddress.Parse(formValues["IP"]),
            };
            try
            {
                Control.Create( address );

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
            var networkAddress = Control.Get( id );

            if( networkAddress == null )
            {
                return HttpNotFound();
            }

            var model = new NetworkingEditModel
            {
                Address = networkAddress,
                AvailableEquipment = ( from equipment in Controls.EquipmentControl.Get()
                                       select new SelectListItem 
                                       {
                                        Selected = equipment.BarCode == networkAddress.InstalledOn.BarCode,
                                        Text = equipment.Description,
                                        Value = equipment.BarCode.ToString()
                                       } ).ToList()
            };

            return View( model );
        }

        //
        // POST: /Networking/Edit/5

        [HttpPost]
        public ActionResult Edit(int id, FormCollection formValues)
        {
            var address = new NetworkAddress
            {
                ID = int.Parse( formValues[ "Address.ID" ] ),
                IP = IPAddress.Parse( formValues[ "Address.IP" ] ),
                InstalledOn = new Equipment { BarCode = int.Parse( formValues[ "InstalledOn.BarCode" ] ) }
            };
            try
            {
                Control.Update( address );

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
