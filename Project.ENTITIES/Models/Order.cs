using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.ENTITIES.Models
{
    public class Order : BaseEntity
    {
        public string ShippedAddress { get; set; }
        public string ShippedCity { get; set; }
        public string ShippedCountry { get; set; }
        public int? AppUserID { get; set; }
        public int? ShipperID { get; set; }

        public decimal TotalPrice { get; set; }
        //Sipariş işlemlerini yakalamak için açılan propertyler
        public string UserName { get; set; }
        public string Email { get; set; }

        

        //Relational Properties
        public virtual AppUser AppUser { get; set; }
        public virtual List<OrderDetail> OrderDetails { get; set; }
        public virtual Shipper Shipper { get; set; }
        
    }
}
