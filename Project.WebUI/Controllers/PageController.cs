using PagedList;
using Project.BLL.DesignPatterns.GenericRepositories.ConcRep;
using Project.WebUI.Models.VMClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Project.WebUI.Controllers
{
    public class PageController : Controller
    {
        BlogRepository bRep;
        ProductRepository pRep;

        public PageController()
        {
            bRep = new BlogRepository();
            pRep = new ProductRepository();
        }
        
        // GET: Page
        public ActionResult Contact()
        {
            return View();
        }

        public ActionResult About()
        {
            return View();
        }

        public ActionResult BlogList(int? page)
        {
            PAVM pvm = new PAVM
            {
                PagedBlogs = bRep.GetActives().ToPagedList(page ?? 1,20) 
            };

            return View(pvm);
        }

        public ActionResult Faq()
        {
            return View();
        }
        
        public ActionResult ProductDetail(int? id)
        {
            ProductVM pvm = new ProductVM
            {
                Product = pRep.FirstOrDefault(x=> x.ID == id)
            };
            return View(pvm);
        }

    }
}