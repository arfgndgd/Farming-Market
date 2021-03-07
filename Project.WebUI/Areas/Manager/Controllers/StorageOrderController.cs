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
    public class StorageOrderController : Controller
    {
        StorageOrderRepository soRep;
        CustomerRepository cRep;
        ShipperRepository sRep;

        public StorageOrderController()
        {
            soRep = new StorageOrderRepository();
            cRep = new CustomerRepository();
            sRep = new ShipperRepository();
        }

        [AllowAnonymous]
        // GET: Manager/StorageOrder
        public ActionResult StorageOrderList()
        {
            StorageOrderVM sovm = new StorageOrderVM
            {
                StorageOrders = soRep.GetAll()
            };
            return View(sovm);
        }

        [ManagerAuthentication]
        public ActionResult AddStorageOrder()
        {
            StorageOrderVM sovm = new StorageOrderVM
            {
                StorageOrder = new StorageOrder(),
                Customers = cRep.GetActives(),
                Shippers = sRep.GetActives()

            };

            return View(sovm);
        }
        [ManagerAuthentication]
        [HttpPost]
        public ActionResult AddOrder(StorageOrder order)
        {
            soRep.Add(order);
            return RedirectToAction("StorageOrderList");

        }

        [ManagerAuthentication]
        public ActionResult UpdateStorageOrder(int id)
        {
            StorageOrderVM sovm = new StorageOrderVM
            {
                StorageOrder = soRep.Find(id),
                Shippers = sRep.GetActives(),
                Customers = cRep.GetActives()
            };
            return View(sovm);
        }
        [ManagerAuthentication]
        [HttpPost]
        public ActionResult UpdateStorageOrder([Bind(Prefix = "StorageOrder")] StorageOrder item)
        {

            soRep.Update(item);
            return RedirectToAction("StorageOrderList");
        }

        [ManagerAuthentication]
        public ActionResult DeleteStorageOrder(int id)
        {
            soRep.Delete(soRep.Find(id));
            return RedirectToAction("StorageOrderList");
        }

        [ManagerAuthentication]
        public ActionResult DestroyStorageOrder(int id)
        {
            soRep.Destroy(soRep.Find(id));
            return RedirectToAction("StorageOrderList");
        }
    }
}