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
    //Customer Storage classları ile ilgilidir. Yalnızca elden satış için açılmıştır. Erişimi Areas içinden ve WFA versiyonu içindir. AppUser Customer ve Product Storage ürünleri farklıdır. 
    [ManagerAuthentication]
    public class StorageOrderDetailController : Controller
    {
        StorageOrderDetailRepository sodRep;
        StorageOrderRepository soRep;
        StorageRepository sRep;

        public StorageOrderDetailController()
        {
            sodRep = new StorageOrderDetailRepository();
            soRep = new StorageOrderRepository();
            sRep = new StorageRepository();
        }

        [AllowAnonymous]
        // GET: Manager/StoragerOrderDetail
        public ActionResult StorageOrderDetailList()
        {
            StorageOrderDetailVM sodvm = new StorageOrderDetailVM
            {
                StorageOrderDetails = sodRep.GetAll()
            };

            return View(sodvm);
        }

        [ManagerAuthentication]
        public ActionResult AddStorageOrderDetail()
        {
            StorageOrderDetailVM sodvm = new StorageOrderDetailVM
            {
                StorageOrderDetail = new StorageOrderDetail(),
                StorageOrders = soRep.GetActives(),
                Storages = sRep.GetActives()

            };

            return View(sodvm);
        }
        [ManagerAuthentication]
        [HttpPost]
        public ActionResult AddStorageOrderDetail(StorageOrderDetail order)
        {
            sodRep.Add(order);
            return RedirectToAction("StorageOrderDetailList");

        }

        [ManagerAuthentication]
        public ActionResult UpdateStorageOrderDetail(int id)
        {
            StorageOrderDetailVM sodvm = new StorageOrderDetailVM
            {
                StorageOrderDetail = sodRep.Find(id),
                StorageOrders = soRep.GetActives(),
                Storages = sRep.GetActives()
            };
            return View(sodvm);
        }
        [ManagerAuthentication]
        [HttpPost]
        public ActionResult UpdateStorageOrderDetail([Bind(Prefix = "StorageOrderDetail")] StorageOrderDetail item)
        {

            sodRep.Update(item);
            return RedirectToAction("StorageOrderDetailList");
        }

        [ManagerAuthentication]
        public ActionResult DeleteStorageOrderDetail(int id)
        {
            sodRep.Delete(sodRep.Find(id));
            return RedirectToAction("StorageOrderDetailList");
        }

        [ManagerAuthentication]
        public ActionResult DestroyStorageOrderDetail(int id)
        {
            sodRep.Destroy(sodRep.Find(id));
            return RedirectToAction("StorageOrderDetailList");
        }
    }
}