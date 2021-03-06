﻿using PagedList;
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
    public class CategoryController : Controller
    {
        CategoryRepository cRep;
        ProductRepository pRep;
        public CategoryController()
        {
            cRep = new CategoryRepository();
            pRep = new ProductRepository();
        }

        // GET: Manager/Category
        public ActionResult CategoryByID(int id)
        {
            CategoryVM cvm = new CategoryVM
            {
                Category = cRep.Find(id)
            };
            return View(cvm);

        }

        [AllowAnonymous]
        public ActionResult CategoryList(int? page, int? categoryID)
        {
            CategoryVM cvm = new CategoryVM
            {
                PagedProducts = categoryID == null ? pRep.GetAll().ToPagedList(page ?? 1, 15) : pRep.Where(x => x.CategoryID == categoryID).ToPagedList(page ?? 1, 15),
                Categories = cRep.GetAll()
            };
            if (categoryID != null)
            {
                TempData["catID"] = categoryID;
            }
            return View(cvm);
        }
        [ManagerAuthentication]
        public ActionResult AddCategory()
        {
            return View();
        }

        [ManagerAuthentication]
        [HttpPost]
        public ActionResult AddCategory(Category category)
        {
            cRep.Add(category);
            return RedirectToAction("CategoryList");
        }
        [ManagerAuthentication]
        public ActionResult UpdateCategory(int id)
        {
            CategoryVM cvm = new CategoryVM
            {
                Category = cRep.Find(id)
            };
            return View(cvm);
        }

        [ManagerAuthentication]
        [HttpPost]
        public ActionResult UpdateCategory(Category category)
        {
            cRep.Update(category);
            return RedirectToAction("CategoryList");
        }

        [ManagerAuthentication]
        public ActionResult DeleteCategory(int id)
        {
            cRep.Delete(cRep.Find(id));
            return RedirectToAction("CategoryList");

        }

        [ManagerAuthentication]
        public ActionResult DestroyCategory(int id)
        {
            cRep.Destroy(cRep.Find(id));
            return RedirectToAction("CategoryList");

        }
    }
}