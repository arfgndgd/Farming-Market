using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.ENTITIES.Models
{
    public class Shipper : BaseEntity
    {
        public string ShipperName { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }

        public Shipper()
        {
            Orders = new List<Order>();
        }
        //Relational Properties
        public virtual List<Order> Orders { get; set; }
    }
}
