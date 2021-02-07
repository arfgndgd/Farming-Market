using Project.BLL.DesignPatterns.GenericRepositories.ConcRep;
using Project.COMMON.Tools;
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
    public class BlogController : Controller
    {
        BlogRepository bRep;
        public BlogController()
        {
            bRep = new BlogRepository();
        }

        [AllowAnonymous]
        // GET: Manager/Blog
        public ActionResult BlogList()
        {
            BlogVM bvm = new BlogVM
            {
                Blogs = bRep.GetAll()
            };
            return View(bvm);
        }

        [ManagerAuthentication]
        public ActionResult AddBlog()
        {
            return View();
        }

        [ManagerAuthentication]
        [HttpPost]
        public ActionResult AddBlog(Blog blog, HttpPostedFileBase resim)
        {
            blog.ImagePath = ImageUploader.UploadImage("~/Pictures", resim);
            bRep.Add(blog);
            return RedirectToAction("BlogList");
        }

        [ManagerAuthentication]
        public ActionResult UpdateBlog(int id)
        {
            BlogVM bvm = new BlogVM
            {
                Blog = bRep.Find(id)
            };
            return View(bvm);
        }

        [ManagerAuthentication]
        [HttpPost]
        public ActionResult UpdateBlog(Blog blog)
        {
            bRep.Update(blog);
            return RedirectToAction("BlogList");
        }

        [ManagerAuthentication]
        public ActionResult DeleteBlog(int id)
        {
            bRep.Delete(bRep.Find(id));
            return RedirectToAction("BlogList");
        }

        [ManagerAuthentication]
        public ActionResult DestroyBlog(int id)
        {
            bRep.Destroy(bRep.Find(id));
            return RedirectToAction("BlogList");
        }

    }
}