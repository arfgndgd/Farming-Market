using Project.BLL.DesignPatterns.GenericRepositories.ConcRep;
using Project.ENTITIES.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Project.WebUI.Controllers
{
    public class AccountController : Controller
    {
        AppUserRepository appRep;
        EmployeeRepository empRep;
        public AccountController()
        {
            appRep = new AppUserRepository();
            empRep = new EmployeeRepository();
        }

        // GET: Account
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(AppUser appUser)
        {
            AppUser hesap = appRep.FirstOrDefault(x => x.UserName == appUser.UserName);
            //Employee admin = empRep.FirstOrDefault(x => x.FirstName == employee.FirstName); prm: ,Employee employee
            //TODO: şifreleme ekle aynı şekilde Registerada 34 satır

                //TODO: member manager nolacak bu dalgalar. Manager farklı controlde mi olmalı
                //if (admin != null && admin.ERole == ENTITIES.Enums.EmployeeRole.Manager)
                //{
                //    Session["manager"] = admin;
                //    return RedirectToAction("ProductList", "Product", new { Area = "Manager" });
                //}
            if (hesap.URole == ENTITIES.Enums.UserRole.Member)
            {
                if (!hesap.Active)
                {
                    return AktifKontrol();
                }
                Session["member"] = hesap;
                return RedirectToAction("ProductList", "Product", new { Area = "Manager" });
                //Burada ShoppingList vardı 
            }
            ViewBag.KullaniciYok = "Kullanıcı bulunamadı";
            return View();
        }


        private ActionResult AktifKontrol()
        {
            ViewBag.AktifDegil = "Lutfen hesabınızı aktif hale getiriniz...Mailinizi kontrol ediniz";
            return View("Login");
        }
    }
}