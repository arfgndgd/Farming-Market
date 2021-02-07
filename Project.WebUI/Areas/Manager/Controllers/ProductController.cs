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
    [ManagerAuthentication]
    //[MemberAuthentication]
    public class ProductController : Controller
    {
        ProductRepository pRep;
        CategoryRepository cRep;
        SupplierRepository sRep;
        public ProductController()
        {
            pRep = new ProductRepository();
            cRep = new CategoryRepository();
            sRep = new SupplierRepository();
        }

        // GET: Manager/Product
        [AllowAnonymous]
        public ActionResult ProductList()
        {
            ProductVM pvm = new ProductVM
            {
                Products = pRep.GetAll()
                //Products = id == null ? pRep.GetAll() : pRep.Where(x => x.CategoryID == id)
                //TODO : burada Supplierla ilgili sorun olabilir, Classında product ve storage listeledim 
            };


            return View(pvm);
        }

        [ManagerAuthentication]
        public ActionResult AddProduct()
        {
            ProductVM pvm = new ProductVM
            {
                Product = new Product(),
                Categories = cRep.GetActives(),
                Suppliers = sRep.GetActives()
            };

            return View(pvm);
        }
        [ManagerAuthentication]
        [HttpPost]
        public ActionResult AddProduct([Bind(Prefix = "Product")] Product item, HttpPostedFileBase resim)
        {
            item.ImagePath = ImageUploader.UploadImage("~/Pictures/", resim);

            pRep.Add(item);
            return RedirectToAction("ProductList");


        }
        [ManagerAuthentication]
        public ActionResult UpdateProduct(int id)
        {
            ProductVM pvm = new ProductVM
            {
                Categories = cRep.GetActives(),
                Suppliers = sRep.GetActives(),
                Product = pRep.Find(id)
            };
            return View(pvm);
        }
        [ManagerAuthentication]
        [HttpPost]
        public ActionResult UpdateProduct([Bind(Prefix = "Product")] Product item, HttpPostedFileBase resim)
        {
            item.ImagePath = ImageUploader.UploadImage("~/Pictures/", resim);
            pRep.Update(item);
            return RedirectToAction("ProductList");
        }

        [ManagerAuthentication]
        public ActionResult DeleteProduct(int id)
        {
            pRep.Delete(pRep.Find(id));
            return RedirectToAction("ProductList");
        }

        [ManagerAuthentication]
        public ActionResult DestroyProduct(int id)
        {
            pRep.Destroy(pRep.Find(id));
            return RedirectToAction("ProductList");
        }
    }
}