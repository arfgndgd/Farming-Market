using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.ENTITIES.Models
{
    public class Customer:BaseEntity
    {
        //AppUser classınndan farklıdır yalnızca yüklü miktarda Storage ürünleri için elden satış için açılmış bir classtır.

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }

        //Relational Properties
        public virtual List<StorageOrder> StorageOrders { get; set; }

    }
}
