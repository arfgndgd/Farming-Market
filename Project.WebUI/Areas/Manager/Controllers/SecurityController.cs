using Project.BLL.DesignPatterns.GenericRepositories.ConcRep;
using Project.DAL.ContextClasses;
using Project.ENTITIES.Models;
using Project.WebUI.Models.VMClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace Project.WebUI.Areas.Manager.Controllers
{
    //[AllowAnonymous]
    public class SecurityController : Controller
    {
        //MyContext db = new MyContext();
        EmployeeRepository emRep;

        public SecurityController()
        {
            emRep = new EmployeeRepository();
        }

        // GET: Manager/Security
        public ActionResult Login()
        {

            return View();
        }
        [HttpPost]
        public ActionResult Login(Employee employee)
        {
            if (!ModelState.IsValid)
            {
                //Validation için 
                return View("Login");
            }

            //Employee login = db.Employees.FirstOrDefault(x => x.TCNO == employee.TCNO && x.Password == employee.Password);

            //if (login != null && login.ERole == ENTITIES.Enums.EmployeeRole.Manager)
            //{
            //    FormsAuthentication.SetAuthCookie(employee.TCNO,false);
            //    Session["manager"] = login;
            //    return RedirectToAction("AddProduct", "Product",new { Area ="Manager"});
            //}
            //else if (login.ERole == ENTITIES.Enums.EmployeeRole.Worker)
            //{
            //    Session["worker"] = login;
            //    return RedirectToAction("ProductList", "Product");
            //}

            //ViewBag.Mesaj = "Böyle bir çalışan yok";
            //return View();
            //&& x.Password == employee.Password

            Employee login = emRep.FirstOrDefault(x => x.TCNO == employee.TCNO );
            if (login == null)
            {
                ViewBag.KullaniciYok = "Böyle bir çalışan yok";
                return View("Login");
            }

            if (login != null && login.Password == employee.Password &&login.ERole == ENTITIES.Enums.EmployeeRole.Manager)
            {
                FormsAuthentication.SetAuthCookie(employee.TCNO, false);
                Session["manager"] = login;
                return RedirectToAction("AddProduct", "Product", new { Area = "Manager" });
            }
            else if (login.ERole == ENTITIES.Enums.EmployeeRole.Worker)
            {
                Session["worker"] = login;
                return RedirectToAction("ProductList", "Product");
            }

            else 
            {
                ViewBag.Mesaj = "Tc No veya şifre yanlış";
                return View("Login");
            }



            //Employee login = _db.Employees.FirstOrDefault(x => x.TCNO == employee.TCNO && x.Password == employee.Password);
            //if (login != null)
            //{
            //    FormsAuthentication.SetAuthCookie(employee.TCNO, false);
            //    return RedirectToAction("ProductList", "Product");
            //}
            //else
            //{
            //    ViewBag.Mesaj = "Böyle bir çalışan yok";
            //    return View();
            //}
        }

        public ActionResult LogOut()
        {
            //FormsAuthentication.SignOut();

            Session.Remove("manager");

            return RedirectToAction("Login");

        
        }

    }
}