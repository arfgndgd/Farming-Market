﻿using Project.BLL.DesignPatterns.GenericRepositories.ConcRep;
using Project.COMMON.Tools;
using Project.ENTITIES.Models;
using Project.WebUI.Models.VMClasses;
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

        public ActionResult LogOut()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Login");
        }

        private ActionResult AktifKontrol()
        {
            ViewBag.AktifDegil = "Lutfen hesabınızı aktif hale getiriniz...Mailinizi kontrol ediniz";
            return View("Login");
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
            toBeUpdated.Password = DantexCrypt.Crypt(appUser.Password);
            toBeUpdated.ConfirmPassword = DantexCrypt.Crypt(appUser.ConfirmPassword);
            appRep.Update(toBeUpdated);

            TempData["Reset"] = "Şifre sıfırlama işleminiz başarılı bir şekilde gerçekleştirilmiştir.";

            return RedirectToAction("Login");
        }
    }
}