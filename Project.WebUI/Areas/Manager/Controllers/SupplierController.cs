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
    public class SupplierController : Controller
    {
        SupplierRepository sRep;
        public SupplierController()
        {
            sRep = new SupplierRepository();
        }
        // GET: Manager/Supplier
        public ActionResult SupplierByID(int id)
        {
            SupplierVM svm = new SupplierVM
            {
                Supplier = sRep.Find(id)
            };
            return View(svm);
        }

        public ActionResult SupplierList()
        {
            SupplierVM svm = new SupplierVM
            {
                Suppliers = sRep.GetAll()
            };
            return View(svm);
        }

        public ActionResult AddSupplier()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddSupplier(Supplier supplier)
        {
            sRep.Add(supplier);
            return RedirectToAction("SupplierList");
        }

        public ActionResult UpdateSupplier(int id)
        {
            SupplierVM svm = new SupplierVM
            {
                Supplier = sRep.Find(id)
            };
            return View(svm);
        }

        [HttpPost]
        public ActionResult UpdateSupplier(Supplier supplier)
        {
            sRep.Update(supplier);
            return RedirectToAction("SupplierList");
        }

        public ActionResult DeleteSupplier(int id)
        {
            sRep.Delete(sRep.Find(id));
            return RedirectToAction("SupplierList");
        }

        public ActionResult DestroySupplier(int id)
        {
            sRep.Destroy(sRep.Find(id));
            return RedirectToAction("SupplierList");
        }
    }
}