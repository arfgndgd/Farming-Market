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
    public class StorageCategoryController : Controller
    {
        StorageCategoryRepository sRep;
        public StorageCategoryController()
        {
            sRep = new StorageCategoryRepository();
        }
        // GET: Manager/StorageCategory
        public ActionResult StorageCategoryByID(int id)
        {
            StorageCategoryVM scvm = new StorageCategoryVM
            {
                StorageCategory = sRep.Find(id)
            };
            return View(scvm);
        }
        [AllowAnonymous]
        public ActionResult StorageCategoryList()
        {
            StorageCategoryVM scvm = new StorageCategoryVM
            {
                StorageCategories = sRep.GetAll()
            };
            return View(scvm);
        }
        [ManagerAuthentication]
        public ActionResult AddStorageCategory()
        {
            return View();
        }
        [ManagerAuthentication]
        [HttpPost]
        public ActionResult AddStorageCategory(StorageCategory storageCategory)
        {
            sRep.Add(storageCategory);
            return RedirectToAction("StorageCategoryList");
        }
        [ManagerAuthentication]
        public ActionResult UpdateStorageCategory(int id)
        {
            StorageCategoryVM scvm = new StorageCategoryVM
            {
                StorageCategory = sRep.Find(id)
            };
            return View(scvm);
        }
        [ManagerAuthentication]
        [HttpPost]
        public ActionResult UpdateStorageCategory(StorageCategory storageCategory)
        {
            sRep.Update(storageCategory);
            return RedirectToAction("StorageCategoryList");
        }
        [ManagerAuthentication]
        public ActionResult DeleteStorageCategory(int id)
        {
            sRep.Delete(sRep.Find(id));
            return RedirectToAction("StorageCategoryList");
        }
        [ManagerAuthentication]
        public ActionResult DestroyStorageCategory(int id)
        {
            sRep.Destroy(sRep.Find(id));
            return RedirectToAction("StorageCategoryList");
        }
    }
}