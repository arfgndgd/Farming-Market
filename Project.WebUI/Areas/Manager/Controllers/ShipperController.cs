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
        public ShipperController()
        {
            sRep = new ShipperRepository();
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
        public ActionResult ShipperList()
        {
            ShipperVM svm = new ShipperVM
            {
                Shippers = sRep.GetAll()
            };
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