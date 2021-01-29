using Project.BLL.DesignPatterns.GenericRepositories.ConcRep;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Project.WebUI.Controllers
{
    public class ShoppingController : Controller
    {
        ProductRepository pRep;
        CategoryRepository cRep;
        OrderRepository oRep;
        OrderDetailRepository odRep;

        public ShoppingController()
        {
            pRep = new ProductRepository();
            cRep = new CategoryRepository();
            oRep = new OrderRepository();
            odRep = new OrderDetailRepository();
        }

        // GET: Shopping
        public ActionResult Index()
        {
            return View();
        }
    }
}