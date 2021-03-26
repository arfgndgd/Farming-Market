using PagedList;
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
    public class DepartmentController : Controller
    {
        DepartmentRepository dRep;
        EmployeeRepository eRep;
        public DepartmentController()
        {
            dRep = new DepartmentRepository();
            eRep = new EmployeeRepository();
        }
        // GET: Manager/Department
        public ActionResult DepartmentByID(int id)
        {
            DepartmentVM dvm = new DepartmentVM
            {
                Department = dRep.Find(id)
            };
            return View();
        }

        [AllowAnonymous]
        public ActionResult DepartmentList(int? page, int? departmentID)
        {
            DepartmentVM dvm = new DepartmentVM
            {
                PagedEmployees = departmentID == null ? eRep.GetAll().ToPagedList(page ?? 1,15) : eRep.Where(x=>x.DepartmentID == departmentID).ToPagedList(page ?? 1, 15),
                Departments = dRep.GetAll()
            };
            if (departmentID != null)
            {
                TempData["depID"] = departmentID;
            }
            return View(dvm);
        }

        [ManagerAuthentication]
        public ActionResult AddDepartment()
        {
            return View();
        }

        [ManagerAuthentication]
        [HttpPost]
        public ActionResult AddDepartment(Department department)
        {
            dRep.Add(department);
            return RedirectToAction("DepartmentList");
        }

        [ManagerAuthentication]
        public ActionResult UpdateDepartment(int id)
        {
            DepartmentVM dvm = new DepartmentVM
            {
                Department = dRep.Find(id)
            };
            return View(dvm);
        }

        [ManagerAuthentication]
        [HttpPost]
        public ActionResult UpdateDepartment(Department department)
        {
            dRep.Update(department);
            return RedirectToAction("DepartmentList");
        }

        [ManagerAuthentication]
        public ActionResult DeleteDepartment(int id)
        {
            dRep.Delete(dRep.Find(id));
            return RedirectToAction("DepartmentList");

        }

        [ManagerAuthentication]
        public ActionResult DestroyDepartment(int id)
        {
            dRep.Destroy(dRep.Find(id));
            return RedirectToAction("DepartmentList");

        }
    }
}