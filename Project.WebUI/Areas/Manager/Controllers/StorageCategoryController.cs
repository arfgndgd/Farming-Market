using Project.BLL.DesignPatterns.GenericRepositories.ConcRep;
using Project.ENTITIES.Models;
using Project.WebUI.Models.VMClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Project.WebUI.Areas.Manager.Controllers
{
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

        public ActionResult StorageCategoryList()
        {
            StorageCategoryVM scvm = new StorageCategoryVM
            {
                StorageCategories = sRep.GetAll()
            };
            return View(scvm);
        }

        public ActionResult AddStorageCategory()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddStorageCategory(StorageCategory storageCategory)
        {
            sRep.Add(storageCategory);
            return RedirectToAction("StorageCategoryList");
        }

        public ActionResult UpdateStorageCategory(int id)
        {
            StorageCategoryVM scvm = new StorageCategoryVM
            {
                StorageCategory = sRep.Find(id)
            };
            return View(scvm);
        }

        [HttpPost]
        public ActionResult UpdateStorageCategory(StorageCategory storageCategory)
        {
            sRep.Update(storageCategory);
            return RedirectToAction("StorageCategoryList");
        }

        public ActionResult DeleteStorageCategory(int id)
        {
            sRep.Delete(sRep.Find(id));
            return RedirectToAction("StorageCategoryList");
        }

        public ActionResult DestroyStorageCategory(int id)
        {
            sRep.Destroy(sRep.Find(id));
            return RedirectToAction("StorageCategoryList");
        }
    }
}