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
    [ManagerAuthentication]
    public class OrderDetailController : Controller
    {
        OrderDetailRepository odRep;
        OrderRepository oRep;
        ProductRepository pRep;

        public OrderDetailController()
        {
            odRep = new OrderDetailRepository();
            oRep = new OrderRepository();
            pRep = new ProductRepository();
        }

        [AllowAnonymous]
        // GET: Manager/OrderDetail
        public ActionResult OrderDetailList(int? page)
        {
            OrderDetailVM odvm = new OrderDetailVM
            {
                PagedOrderDetails = odRep.GetAll().ToPagedList(page ?? 1,15)
            };
            if (true)
            {
                TempData["ordID"] = true;
            }
            return View(odvm);
        }

        [ManagerAuthentication]
        public ActionResult AddOrderDetail()
        {
            OrderDetailVM odvm = new OrderDetailVM
            {
                OrderDetail = new OrderDetail(),
                Orders = oRep.GetActives(),
                Products = pRep.GetActives()

            };

            return View(odvm);
        }
        [ManagerAuthentication]
        [HttpPost]
        public ActionResult AddOrderDetail(OrderDetail order)
        {
            odRep.Add(order);
            return RedirectToAction("OrderDetailList");

        }

        [ManagerAuthentication]
        public ActionResult UpdateOrderDetail(int id)
        {
            OrderDetailVM ovm = new OrderDetailVM
            {
                OrderDetail = odRep.Find(id),
                Orders = oRep.GetActives(),
                Products = pRep.GetActives()
            };
            return View(ovm);
        }
        [ManagerAuthentication]
        [HttpPost]
        public ActionResult UpdateOrderDetail([Bind(Prefix = "OrderDetail")] OrderDetail item)
        {

            odRep.Update(item);
            return RedirectToAction("OrderDetailList");
        }

        [ManagerAuthentication]
        public ActionResult DeleteOrderDetail(int id)
        {
            odRep.Delete(odRep.Find(id));
            return RedirectToAction("OrderDetailList");
        }

        [ManagerAuthentication]
        public ActionResult DestroyOrderDetail(int id)
        {
            odRep.Destroy(odRep.Find(id));
            return RedirectToAction("OrderDetailList");
        }
    }
}