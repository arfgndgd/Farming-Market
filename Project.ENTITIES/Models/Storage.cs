using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.ENTITIES.Models
{
    public class Storage : BaseEntity
    {
        //Üretim için ürün depolama sınıfı 

        public string ProductName { get; set; }
        public decimal UnitInPrice { get; set; }
        public string ImagePath { get; set; }
        public int? SupplierID { get; set; }
        public int? StorageCategoryID { get; set; }

        //TODO: kilo * fiyat hesaplaması 
    }
}
