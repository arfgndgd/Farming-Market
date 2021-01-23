using Project.ENTITIES.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.ENTITIES.Models
{
    public class Employee : BaseEntity
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string Photo { get; set; }
        public string TCNO { get; set; }
        public EmployeeRole ERole { get; set; }
        public int? DepartmentID { get; set; }
        public EmployeeGender Gender { get; set; }
        public string Password { get; set; }

        public Employee()
        {
            ERole = EmployeeRole.Worker;
        }

        //Relational Properties
        public virtual Department Department { get; set; }

        //TODO: Order ilişkisi eklenecek ya da direkt olarak Product ve Storage ile ilişkilenmeli ki crud işlemleri yapılsın
    }
}
