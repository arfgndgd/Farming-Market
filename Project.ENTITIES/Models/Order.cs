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

        //public DateTime? OrderDate { get; set; }
        //public Order()
        //{
        //    OrderDate = DateTime.Now; 
        //}
        //TODO: Çalışır mı? BaseEntityde olan CreatedDate sayesinde gerek kalmaz mı?

        public decimal TotalPrice { get; set; }
        //Sipariş işlemlerini yakalamak için açılan propertyler
        public string UserName { get; set; }
        public string Email { get; set; }
        public string EmailAddress { get; set; } // TODO: bunları niye kullandık araştır

    }
}
