using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.ENTITIES.Models
{
    public class StorageOrderDetail : BaseEntity
    {
        public int StorageID { get; set; }
        public int OrderID { get; set; }
        public decimal TotalPrice { get; set; }
        public double Weight { get; set; }
        //TODO: hesaplamayı düşün


        //Relational Properties
        public virtual Storage Storage { get; set; }
        public virtual Order Order { get; set; }
    }
}
