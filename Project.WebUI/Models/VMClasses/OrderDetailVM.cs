using Project.ENTITIES.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Project.WebUI.Models.VMClasses
{
    public class OrderDetailVM
    {
        //OrderDetails controlü için
        public List<Product> Products { get; set; }
        public OrderDetail OrderDetail { get; set; }
        public List<OrderDetail> OrderDetails { get; set; }
        public List<Order> Orders { get; set; }
    }
}