using Project.BLL.DesignPatterns.GenericRepositories.ConcRep;
using Project.COMMON.Tools;
using Project.ENTITIES.Models;
using Project.WebUI.Models.VMClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using System.Web.SessionState;

namespace Project.WebUI.Controllers
{
    public class AccountController : Controller
    {
        AppUserRepository appRep;
        OrderRepository oRep;
        OrderDetailRepository odRep;
        UserProfileRepository uRep;

        public AccountController()
        {
            appRep = new AppUserRepository();
            oRep = new OrderRepository();
            odRep = new OrderDetailRepository();
            uRep = new UserProfileRepository();
        }

        // GET: Account
        public ActionResult Login()
        {
            return View();
        }
        
        [HttpPost]
        public ActionResult Login(AppUser appUser)
        {
            AppUser account = appRep.FirstOrDefault(x => x.UserName == appUser.UserName||x.Email == appUser.Email);
            //kullanıcı adı ya da email

            string decrypted = DantexCrypt.DeCrypt(account.Password);         
           
            if (appUser.Password == decrypted && account != null && account.URole == ENTITIES.Enums.UserRole.Member)
            {
                if (!account.Active)
                {
                    return ActiveControl();
                }

                //FormsAuthentication.SetAuthCookie(appUser.UserName, appUser.RememberMe);
                //Beni hatırla butonu için
                Session["member"] = account;
                return RedirectToAction("ShoppingList", "Shopping");
                //Burada ShoppingList vardı 
            }

            ViewBag.KullaniciYok = "Kullanıcı Bulunamadı";
            return View();
        }

        public ActionResult LogOut()
        {

            //FormsAuthentication.SignOut();
            Session.Remove("member");
            return RedirectToAction("Login");
        }

        private ActionResult ActiveControl()
        {
            ViewBag.AktifDegil = "Lutfen hesabınızı aktif hale getiriniz...Mailinizi kontrol ediniz";
            return View("Login");
        }

        public ActionResult UserProfile(int? appUserID)
        {
            if (Session["member"] != null)
            {
                UserProfileVM avm = new UserProfileVM
                {
                    Orders =  oRep.Where(x=>x.AppUserID == appUserID).ToList()
                    
                };
                return View(avm);
            }
            TempData["giris"] = "Önce giriş yapınız";
            return RedirectToAction("Login");
        }

        public ActionResult LostPassword()
        {
            return View();
        }

        [HttpPost]
        public ActionResult LostPassword(AppUserVM auvm)
        {
            AppUser resetPassword = appRep.FirstOrDefault(x => x.Email == auvm.AppUser.Email);
            if (resetPassword !=null)
            {
                string guidMail = "Şifre sıfırlama işlemini başlatmak için yandaki bağlantıya tıklayabilirsiniz https://localhost:44317/Account/ResetPassword/" + resetPassword.ActivationCode;
                MailSender.Send(receiver: resetPassword.Email, body: guidMail, subject: "Şifre Sıfırlama");
                ViewBag.Metin = "Şifre sıfırlama bağlantısı mail adresinize gönderilmiştir.";
                
            }
            else
            {
                ViewBag.Metin = "Kullanıcı kaydı bulunamadı";
            }
            return View();
        }

        public ActionResult ResetPassword(Guid id)
        {
            AppUserVM auvm = new AppUserVM();
            auvm.AppUser = appRep.FirstOrDefault(x => x.ActivationCode == id);
            return View(auvm);
        }

        [HttpPost]
        public ActionResult ResetPassword(AppUser appUser)//TODO : toBeUpdated Null geliyor bakılacak.
        {
            //ModelState.Remove("AppUser.UserName");
            if (!ModelState.IsValid)
            {
                return View();

            }
            AppUser toBeUpdated = appRep.FirstOrDefault(x => x.ActivationCode == appUser.ActivationCode);
            //toBeUpdated = appRep.Find(appUser.id);
            toBeUpdated.Password = DantexCrypt.Crypt(appUser.Password);
            toBeUpdated.ConfirmPassword = DantexCrypt.Crypt(appUser.ConfirmPassword);
            appRep.Update(toBeUpdated);

            TempData["Reset"] = "Şifre sıfırlama işleminiz başarılı bir şekilde gerçekleştirilmiştir.";

            return RedirectToAction("Login");
        }
    }
}