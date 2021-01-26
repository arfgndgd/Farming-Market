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

        [AllowAnonymous]
        public ActionResult SupplierList()
        {
            SupplierVM svm = new SupplierVM
            {
                Suppliers = sRep.GetAll()
            };
            return View(svm);
        }

        [ManagerAuthentication]
        public ActionResult AddSupplier()
        {
            return View();
        }

        [ManagerAuthentication]
        [HttpPost]
        public ActionResult AddSupplier(Supplier supplier)
        {
            sRep.Add(supplier);
            return RedirectToAction("SupplierList");
        }

        [ManagerAuthentication]
        public ActionResult UpdateSupplier(int id)
        {
            SupplierVM svm = new SupplierVM
            {
                Supplier = sRep.Find(id)
            };
            return View(svm);
        }

        [ManagerAuthentication]
        [HttpPost]
        public ActionResult UpdateSupplier(Supplier supplier)
        {
            sRep.Update(supplier);
            return RedirectToAction("SupplierList");
        }

        [ManagerAuthentication]
        public ActionResult DeleteSupplier(int id)
        {
            sRep.Delete(sRep.Find(id));
            return RedirectToAction("SupplierList");
        }

        [ManagerAuthentication]
        public ActionResult DestroySupplier(int id)
        {
            sRep.Destroy(sRep.Find(id));
            return RedirectToAction("SupplierList");
        }
    }
}