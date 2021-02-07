using Project.BLL.DesignPatterns.GenericRepositories.ConcRep;
using Project.COMMON.Tools;
using Project.ENTITIES.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace Project.WebUI.Controllers
{
    public class AccountController : Controller
    {
        AppUserRepository appRep;
        //EmployeeRepository empRep;
        public AccountController()
        {
            appRep = new AppUserRepository();
            //empRep = new EmployeeRepository();
        }

        // GET: Account
        public ActionResult Login(/*string ReturnUrl*/)
        {
            //ViewBag.ReturnUrl = ReturnUrl;
            return View();
        }
        
        [HttpPost]
        public ActionResult Login(AppUser appUser, string ReturnUrl)
        {
            AppUser hesap = appRep.FirstOrDefault(x => x.UserName == appUser.UserName||x.Email == appUser.Email);
            //kullanıcı adı ya da email

            string decrypted = DantexCrypt.DeCrypt(hesap.Password);         
           
            if (appUser.Password == decrypted && hesap != null && hesap.URole == ENTITIES.Enums.UserRole.Member)
            {
                if (!hesap.Active)
                {
                    return AktifKontrol();
                }

                //FormsAuthentication.SetAuthCookie(appUser.UserName, appUser.RememberMe);
                //Beni hatırla butonu için
                
                Session["member"] = hesap;
                return RedirectToAction("ShoppingList", "Shopping");
                //Burada ShoppingList vardı 
            }

            ViewBag.KullaniciYok = "Kullanıcı Bulunamadı";
            return View();
        }

        //public ActionResult LogOut()
        //{
        //    FormsAuthentication.SignOut();
        //    return RedirectToAction("Login", "Account");
        //}

        private ActionResult AktifKontrol()
        {
            ViewBag.AktifDegil = "Lutfen hesabınızı aktif hale getiriniz...Mailinizi kontrol ediniz";
            return View("Login");
        }
    }
}