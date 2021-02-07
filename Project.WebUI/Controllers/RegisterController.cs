using Project.BLL.DesignPatterns.GenericRepositories.ConcRep;
using Project.COMMON.Tools;
using Project.ENTITIES.Models;
using Project.WebUI.Models.VMClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Project.WebUI.Controllers
{
    public class RegisterController : Controller
    {
        AppUserRepository apRep;
        UserProfileRepository usRep;
        
        public RegisterController()
        {
            apRep = new AppUserRepository();
            usRep = new UserProfileRepository();
         
        }
        // GET: Register
        public ActionResult RegisterNow()
        {
            return View();
        }

        [HttpPost]
        public ActionResult RegisterNow(AppUserVM apvm)
        {
            if (!ModelState.IsValid)
            {
                return View("RegisterNow");
            }
            AppUser appUser = apvm.AppUser;
            UserProfile profile = apvm.UserProfile;

            appUser.Password = DantexCrypt.Crypt(appUser.Password);
            appUser.ConfirmPassword = DantexCrypt.Crypt(appUser.ConfirmPassword);
            //Kayıt işlemi
            if (apRep.Any(x => x.UserName == appUser.UserName))
            {
                ViewBag.ZatenVar = "Kullanıcı ismi alınmış";
                return View();
            }
            else if (apRep.Any(x => x.Email == appUser.Email))
            {
                ViewBag.ZatenVar = "Email kayıtlı";
                return View();
            }

            //Başarılı kayıt sonrası mail gönderme işlemi
            string hesapKayit = "Tebrikler, hesabınız oluşturulmuştur. Hesabınızı aktive etmek için https://localhost:44317/Register/Activation/" + appUser.ActivationCode + " linkine tıklayabilirsiniz.";

            MailSender.Send(appUser.Email, body: hesapKayit, subject: "Hesap Aktivasyon!");
            apRep.Add(appUser);

            if (!string.IsNullOrEmpty(profile.FirstName) || !string.IsNullOrEmpty(profile.LastName) || !string.IsNullOrEmpty(profile.Address))
            {
                profile.ID = appUser.ID;
                usRep.Add(profile);
            }
            return View("RegisterSuccess");
        }

        public ActionResult RegisterSuccess()
        {
            //TODO: gmail linki ekle 
            return View();
        }

        public ActionResult Activation(Guid id)
        {
            AppUser hesapAktif = apRep.FirstOrDefault(x => x.ActivationCode == id);
            if (hesapAktif != null)
            {
                hesapAktif.Active = true;
                apRep.Update(hesapAktif);

                TempData["HesapAktifmi"] = "Hesap aktivasyonu tamamlandı";
                return RedirectToAction("Login", "Account");
            }
            TempData["HesapAktifmi"] = "Aktif edilecek hesap bulunamadı";
            return RedirectToAction("Login", "Account");
        }

    }
}