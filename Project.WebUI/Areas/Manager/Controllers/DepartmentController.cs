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
    //[ManagerAuthentication]
    public class DepartmentController : Controller
    {
        DepartmentRepository dRep;
        public DepartmentController()
        {
            dRep = new DepartmentRepository();
        }
        // GET: Manager/Department
        public ActionResult DepartmentByID(int id)
        {
            DepartmentVM dvm = new DepartmentVM
            {
                Department = dRep.Find(id)
            };
            return View();
            //TODO: bu ne işe yarıyordu
        }

        //[AllowAnonymous]
        public ActionResult DepartmentList()
        {
            DepartmentVM dvm = new DepartmentVM
            {
                Departments = dRep.GetAll()
            };
            return View(dvm);
        }

        public ActionResult AddDepartment()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddDepartment(Department department)
        {
            dRep.Add(department);
            return RedirectToAction("DepartmentList");
        }

        public ActionResult UpdateDepartment(int id)
        {
            DepartmentVM dvm = new DepartmentVM
            {
                Department = dRep.Find(id)
            };
            return View(dvm);
        }

        [HttpPost]
        public ActionResult UpdateDepartment(Department department)
        {
            dRep.Update(department);
            return RedirectToAction("DepartmentList");
        }
        public ActionResult DeleteDepartment(int id)
        {
            dRep.Delete(dRep.Find(id));
            return RedirectToAction("DepartmentList");

        }

        public ActionResult DestroyDepartment(int id)
        {
            dRep.Destroy(dRep.Find(id));
            return RedirectToAction("DepartmentList");

        }
    }
}