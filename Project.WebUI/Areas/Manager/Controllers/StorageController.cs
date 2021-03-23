using PagedList;
using Project.BLL.DesignPatterns.GenericRepositories.ConcRep;
using Project.COMMON.Tools;
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
    public class StorageController : Controller
    {
        StorageRepository sRep;
        StorageCategoryRepository cRep;
        SupplierRepository supRep;

        public StorageController()
        {
            sRep = new StorageRepository();
            cRep = new StorageCategoryRepository();
            supRep = new SupplierRepository();
        }

        [AllowAnonymous]
        // GET: Manager/Storage
        public ActionResult StorageList(int? page)
        {
            StorageVM svm = new StorageVM
            {
                PagedStorages = sRep.GetAll().ToPagedList(page ?? 1, 15)
            };
            if (true)
            {
                TempData["stoID"] = true;
            }
            return View(svm);
        }

        [ManagerAuthentication]
        public ActionResult AddStorage()
        {
            StorageVM svm = new StorageVM
            {
                Storage = new Storage(),
                StorageCategories = cRep.GetActives(),
                Suppliers = supRep.GetActives()
            };
            return View(svm);

        }

        [ManagerAuthentication]
        [HttpPost]
        public ActionResult AddStorage(Storage storage, HttpPostedFileBase resim)
        {
            storage.ImagePath = ImageUploader.UploadImage("~/Pictures", resim);
            sRep.Add(storage);
            return RedirectToAction("StorageList");
        }

        [ManagerAuthentication]
        public ActionResult UpdateStorage(int id)
        {
            StorageVM svm = new StorageVM
            {
                Storage = sRep.Find(id),
                StorageCategories = cRep.GetActives(),
                Suppliers = supRep.GetActives()
            };
            return View(svm);
        }

        [ManagerAuthentication]
        [HttpPost]
        public ActionResult UpdateStorage(Storage storage, HttpPostedFileBase resim)
        {
            storage.ImagePath = ImageUploader.UploadImage("~/Pictures", resim);
            sRep.Update(storage);
            return RedirectToAction("StorageList");
        }

        [ManagerAuthentication]
        public ActionResult DeleteStorage(int id)
        {
            sRep.Delete(sRep.Find(id));
            return RedirectToAction("StorageList");
        }

        [ManagerAuthentication]
        public ActionResult DestroyStorage(int id)
        {
            sRep.Destroy(sRep.Find(id));
            return RedirectToAction("StorageList");
        }
    }
}