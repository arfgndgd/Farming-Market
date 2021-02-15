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

        public PageController()
        {
            bRep = new BlogRepository();
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
                PagedBlogs = bRep.GetActives().ToPagedList(page ?? 1,6) 
            };

            return View(pvm);
        }

        public ActionResult Faq()
        {
            return View();
        }
        
       

    }
}