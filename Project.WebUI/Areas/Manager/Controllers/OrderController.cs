﻿using Project.BLL.DesignPatterns.GenericRepositories.ConcRep;
using Project.ENTITIES.Models;
using Project.WebUI.AuthenticationClasses;
using Project.WebUI.Models.VMClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Project.WebUI.Areas.Manager.Controllers
{
    [ManagerAuthentication]
    public class OrderController : Controller
    {
        OrderRepository oRep;
        AppUserRepository aRep;
        ShipperRepository sRep;

        public OrderController()
        {
            oRep = new OrderRepository();
            aRep = new AppUserRepository();
            sRep = new ShipperRepository();
        }

        [AllowAnonymous]
        // GET: Manager/Order
        public ActionResult OrderList()
        {
            OrderVM ovm = new OrderVM
            {
                Orders = oRep.GetAll()  
            };
            return View(ovm);
        }


        [ManagerAuthentication]
        public ActionResult AddOrder()
        {
            OrderVM ovm = new OrderVM
            {
                Order = new Order(),
                AppUsers = aRep.GetActives(),
                Shippers = sRep.GetActives()

            };

            return View(ovm);
        }
        [ManagerAuthentication]
        [HttpPost]
        public ActionResult AddOrder(Order order)
        {
            oRep.Add(order);
            return RedirectToAction("OrderList");

        }

        [ManagerAuthentication]
        public ActionResult UpdateOrder(int id)
        {
            OrderVM ovm = new OrderVM
            {
                Order = oRep.Find(id),
                Shippers = sRep.GetActives(),
                AppUsers = aRep.GetActives()
            };
            return View(ovm);
        }
        [ManagerAuthentication]
        [HttpPost]
        public ActionResult UpdateOrder([Bind(Prefix = "Order")] Order item)
        {
           
            oRep.Update(item);
            return RedirectToAction("OrderList");
        }

        [ManagerAuthentication]
        public ActionResult DeleteOrder(int id)
        {
            oRep.Delete(oRep.Find(id));
            return RedirectToAction("OrderList");
        }

        [ManagerAuthentication]
        public ActionResult DestroyOrder(int id)
        {
            oRep.Destroy(oRep.Find(id));
            return RedirectToAction("OrderList");
        }
    }
}