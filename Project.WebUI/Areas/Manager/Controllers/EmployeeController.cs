using PagedList;
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
    public class EmployeeController : Controller
    {
        EmployeeRepository eRep;
        DepartmentRepository dRep;
        public EmployeeController()
        {
            eRep = new EmployeeRepository();
            dRep = new DepartmentRepository();
        }

        [AllowAnonymous]
        // GET: Manager/Employee
        public ActionResult EmployeeList(int? page)
        {
            EmployeeVM evm = new EmployeeVM
            {
                PagedEmployees = eRep.GetAll().ToPagedList(page ?? 1, 15)
            };
            if (true)
            {
                TempData["empID"] = true;
            }
            return View(evm);
        }

        [ManagerAuthentication]
        public ActionResult AddEmployee()
        {
            EmployeeVM evm = new EmployeeVM
            {
                Employee = new Employee(),
                Departments = dRep.GetActives()
            };
            return View(evm);
        }

        [ManagerAuthentication]
        [HttpPost]
        public ActionResult AddEmployee(Employee employee, HttpPostedFileBase resim)
        {
            //TODO: Dosya yolunu değiştiremiyorum ve güncellenmede resim kayboluyor 
            employee.Photo = ImageUploader.UploadImage("~/Pictures/", resim);
            eRep.Add(employee);
            return RedirectToAction("EmployeeList"); 
        }

        [ManagerAuthentication]
        public ActionResult UpdateEmployee(int id)
        {
            EmployeeVM evm = new EmployeeVM
            {
                Departments = dRep.GetActives(),
                Employee = eRep.Find(id)
            };
            return View(evm);
        }

        [ManagerAuthentication]
        [HttpPost]
        public ActionResult UpdateEmployee(Employee employee)
        {

          
            eRep.Update(employee);
            return RedirectToAction("EmployeeList");
        }

        [ManagerAuthentication]
        public ActionResult DeleteEmployee(int id)
        {
            eRep.Delete(eRep.Find(id));
            return RedirectToAction("EmployeeList");
        }
        [ManagerAuthentication]
        public ActionResult DestroyEmployee(int id)
        {
            eRep.Destroy(eRep.Find(id));
            return RedirectToAction("EmployeeList");
        }

    }
}