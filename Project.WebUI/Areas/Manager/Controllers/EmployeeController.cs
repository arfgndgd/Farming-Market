﻿using Project.BLL.DesignPatterns.GenericRepositories.ConcRep;
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
    //[ManagerAuthentication]
    public class EmployeeController : Controller
    {
        //TODO: Authorize nasıl yapılır (coredan farklı galiba)
        EmployeeRepository eRep;
        DepartmentRepository dRep;
        public EmployeeController()
        {
            eRep = new EmployeeRepository();
            dRep = new DepartmentRepository();
        }

        //[AllowAnonymous]
        // GET: Manager/Employee
        public ActionResult EmployeeList()
        {
            EmployeeVM evm = new EmployeeVM
            {
                Employees = eRep.GetAll()
            };
            return View(evm);
        }

        public ActionResult AddEmployee()
        {
            EmployeeVM evm = new EmployeeVM
            {
                Employee = new Employee(),
                Departments = dRep.GetActives()
            };
            return View(evm);
        }

        [HttpPost]
        public ActionResult AddEmployee(Employee employee, HttpPostedFileBase resim)
        {
            //TODO: Dosya yolunu değiştiremiyorum ve güncellenmede resim kayboluyor
            employee.Photo = ImageUploader.UploadImage("~/Pictures/", resim);
            eRep.Add(employee);
            return RedirectToAction("EmployeeList"); 
        }

        public ActionResult UpdateEmployee(int id)
        {
            EmployeeVM evm = new EmployeeVM
            {
                Departments = dRep.GetActives(),
                Employee = eRep.Find(id)
            };
            return View(evm);
        }

        [HttpPost]
        public ActionResult UpdateEmployee(Employee employee)
        {

          
            eRep.Update(employee);
            return RedirectToAction("EmployeeList");
        }
        public ActionResult DeleteEmployee(int id)
        {
            eRep.Delete(eRep.Find(id));
            return RedirectToAction("EmployeeList");
        }

        public ActionResult DestroyEmployee(int id)
        {
            eRep.Destroy(eRep.Find(id));
            return RedirectToAction("EmployeeList");
        }

    }
}