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
    [AllowAnonymous]
    public class SecurityController : Controller
    {
        MyContext db = new MyContext();
        
        //public SecurityController()
        //{
        //    emRep = new EmployeeRepository();
        //}

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
            Employee login = db.Employees.FirstOrDefault(x => x.TCNO == employee.TCNO && x.Password == employee.Password);
            if (login != null)
            {
                FormsAuthentication.SetAuthCookie(employee.TCNO,false);
                return RedirectToAction("ProductList", "Product");
            }
            else
            {
                ViewBag.Mesaj = "Böyle bir çalışan yok";
                return View();
            }

            //Employee login = emRep.(x => x.TCNO == employee.Employee.TCNO && x.Password == employee.Employee.Password);
            //if (login != null)
            //{
            //    FormsAuthentication.SetAuthCookie(employee.Employee.TCNO, false);
            //    return RedirectToAction("ProductList", "Product");
            //}
            //else
            //{
            //    ViewBag.Mesaj = "Böyle bir çalışan yok";
            //    return View();
            //}

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
            FormsAuthentication.SignOut();
            return RedirectToAction("Login");
        }
    }
}