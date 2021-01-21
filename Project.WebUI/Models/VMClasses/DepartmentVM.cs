using Project.ENTITIES.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Project.WebUI.Models.VMClasses
{
    public class DepartmentVM
    {
        public Department Department { get; set; }
        public List<Department> Departments { get; set; }
    }
}