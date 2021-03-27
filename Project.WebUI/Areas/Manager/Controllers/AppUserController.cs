using Project.BLL.DesignPatterns.GenericRepositories.ConcRep;
using Project.WebUI.Models.VMClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList;
using Project.WebUI.AuthenticationClasses;
using Project.ENTITIES.Models;
using Project.COMMON.Tools;

namespace Project.WebUI.Areas.Manager.Controllers
{
    [ManagerAuthentication]

    public class AppUserController : Controller
    {
        AppUserRepository aRep;
        UserProfileRepository uRep;
        OrderRepository oRep;

        public AppUserController()
        {
            aRep = new AppUserRepository();
            uRep = new UserProfileRepository();
            oRep = new OrderRepository();

        }

        // GET: Manager/AppUser
        public ActionResult ShipperByID(int id)
        {
            AppUserVM avm = new AppUserVM
            {
                AppUser = aRep.Find(id)
            };
            return View(avm);
        }

        [AllowAnonymous]
        public ActionResult AppUserList(int? page, int? appUserID)
        {
            //AppUser appUser = aRep.Find();

            //string decrypted = DantexCrypt.DeCrypt(appUser.Password);
            
            AppUserVM avm = new AppUserVM
            {
                PagedOrders = appUserID == null ? oRep.GetAll().ToPagedList(page ?? 1, 15) : oRep.Where(x => x.AppUserID == appUserID).ToPagedList(page ?? 1, 15),
                AppUsers = aRep.GetAll()
                
            };
            if (appUserID != null)
            {
                TempData["appID"] = appUserID;
            }
            return View(avm);
        }

        //[ManagerAuthentication]
        //public ActionResult AddAppUser()
        //{
        //    return View();
        //}

        //[ManagerAuthentication]
        //[HttpPost]
        //public ActionResult AddAppUser(AppUser appUser)
        //{
        //    aRep.Add(appUser);
        //    return RedirectToAction("AppUserList");
        //}

        //[ManagerAuthentication]
        //public ActionResult UpdateAppUser(int id)
        //{
        //    AppUserVM avm = new AppUserVM
        //    {
        //        AppUser = aRep.Find(id)
        //    };
        //    return View(avm);
        //}

        //[ManagerAuthentication]
        //[HttpPost]
        //public ActionResult UpdateAppUser(AppUser appUser)
        //{
        //    aRep.Update(appUser);
        //    return RedirectToAction("AppUserList");
        //}

        //[ManagerAuthentication]
        //public ActionResult DeleteAppUser(int id)
        //{
        //    aRep.Delete(aRep.Find(id));
        //    return RedirectToAction("AppUserList");
        //}

        //[ManagerAuthentication]
        //public ActionResult DestroyAppUser(int id)
        //{
        //    aRep.Destroy(aRep.Find(id));
        //    return RedirectToAction("AppUserList");
        //}
    }
}