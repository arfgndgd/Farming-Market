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
    //Yalnızca stok ürün için açılmıştır
    [ManagerAuthentication]
    public class StorageCategoryController : Controller
    {
        StorageCategoryRepository sRep;
        StorageRepository stRep;
        public StorageCategoryController()
        {
            sRep = new StorageCategoryRepository();
            stRep = new StorageRepository();
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
        public ActionResult StorageCategoryList(int? page, int? sCategoryID)
        {
            StorageCategoryVM scvm = new StorageCategoryVM
            {
                PagedStorages = sCategoryID == null ? stRep.GetAll().ToPagedList(page ?? 1,15): stRep.Where(x=>x.StorageCategoryID == sCategoryID).ToPagedList(page ?? 1,15),

                StorageCategories = sRep.GetAll()
            };
            if (sCategoryID != null)
            {
                TempData["sCatID"] = sCategoryID;
            }
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