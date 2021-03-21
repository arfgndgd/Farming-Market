using PagedList;
using Project.BLL.DesignPatterns.GenericRepositories.ConcRep;
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
    public class ShipperController : Controller
    {
        ShipperRepository sRep;
        OrderRepository oRep;
        public ShipperController()
        {
            sRep = new ShipperRepository();
            oRep = new OrderRepository();
        }
        // GET: Manager/Default
        public ActionResult ShipperByID(int id)
        {
            ShipperVM svm = new ShipperVM
            {
                Shipper = sRep.Find(id)
            };
            return View(svm);
        }
        
        [AllowAnonymous]
        public ActionResult ShipperList(int? page, int? shipperID)
        {
            ShipperVM svm = new ShipperVM
            {
                PagedOrders = shipperID == null ? oRep.GetAll().ToPagedList(page ?? 1,15) : oRep.Where(x=>x.ShipperID == shipperID).ToPagedList(page ?? 1, 15),
                Shippers = sRep.GetAll()
            };
            if (shipperID != null)
            {
                TempData["shipID"] = shipperID;
            }
            return View(svm);
        }

        [ManagerAuthentication]
        public ActionResult AddShipper()
        {
            return View();
        }

        [ManagerAuthentication]
        [HttpPost]
        public ActionResult AddShipper(Shipper shipper)
        {
            sRep.Add(shipper);
            return RedirectToAction("ShipperList");
        }

        [ManagerAuthentication]
        public ActionResult UpdateShipper(int id)
        {
            ShipperVM svm = new ShipperVM
            {
                Shipper = sRep.Find(id)
            };
            return View(svm);
        }

        [ManagerAuthentication]
        [HttpPost]
        public ActionResult UpdateShipper(Shipper shipper)
        {
            sRep.Update(shipper);
            return RedirectToAction("ShipperList");
        }

        [ManagerAuthentication]
        public ActionResult DeleteShipper(int id)
        {
            sRep.Delete(sRep.Find(id));
            return RedirectToAction("ShipperList");
        }

        [ManagerAuthentication]
        public ActionResult DestroyShipper(int id)
        {
            sRep.Destroy(sRep.Find(id));
            return RedirectToAction("ShipperList");
        }
    }
}