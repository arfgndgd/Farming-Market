﻿//using Project.BLL.DesignPatterns.GenericRepositories.ConcRep;
//using Project.COMMON.Tools;
//using Project.ENTITIES.Models;
//using Project.WebUI.Models.VMClasses;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Web;
//using System.Web.Mvc;

//namespace Project.WebUI.Controllers
//{
//    public class EmployeeRegisterController : Controller
//    {
//        EmployeeRepository emRep;
//        public EmployeeRegisterController()
//        {
//            emRep = new EmployeeRepository();
//        }
//        // GET: EmployeeRegister
//        public ActionResult EmployeeRegisterNow()
//        {
//            return View();
//        }

//        [HttpPost]
//        public ActionResult EmployeeRegisterNow(EmployeeVM empvm)
//        {

//            Employee employee = empvm.Employee;
//            if (!ModelState.IsValid)
//            {
//                //Validation için 
//                return View("EmployeeRegisterNow");
//            }
//            //empvm.Employee.Password = DantexCrypt.Crypt(empvm.Employee.Password);
//            //empvm.Employee.ConfirmPassword = DantexCrypt.Crypt(empvm.Employee.ConfirmPassword)

//            if (emRep.Any(x=>x.TCNO==empvm.Employee.TCNO))
//            {
//                ViewBag.ZatenVar = "Bu Tc Nolu çalışan var";
//                return View();
//            }

//            emRep.Add(employee);

//            if (!string.IsNullOrEmpty(empvm.Employee.FirstName) || !string.IsNullOrEmpty(empvm.Employee.LastName) || !string.IsNullOrEmpty(empvm.Employee.Email))
//            {
//                empvm.Employee.ID = empvm.Employee.ID;
//                emRep.Add(employee);
//            }
//            return View();

//        }
       

//    }
//}