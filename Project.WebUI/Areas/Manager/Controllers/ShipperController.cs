using Project.BLL.DesignPatterns.GenericRepositories.ConcRep;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Project.WebUI.Areas.Manager.Controllers
{
    public class ShipperController : Controller
    {
        ShipperRepository sRep;
        public ShipperController()
        {
            sRep = new ShipperRepository();
        }
        // GET: Manager/Default
        public ActionResult ShipperByID(int id)
        {

            return View();
        }
    }
}