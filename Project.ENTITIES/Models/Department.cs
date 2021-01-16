using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.ENTITIES.Models
{
    public class Department : BaseEntity
    {
        public string DepartmentName { get; set; }
        public string Description { get; set; }

        public Department()
        {
            Employees = new List<Employee>();
        }

        //Relational Properties
        public virtual List<Employee> Employees { get; set; }
    }
}
