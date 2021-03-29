using Project.ENTITIES.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Project.WebUI.Models.VMClasses
{
    public class UserProfileVM
    {
        public AppUser AppUser { get; set; }
        public List<AppUser> AppUsers { get; set; }
        public UserProfile UserProfile { get; set; }
        public Order Order { get; set; }
        public List<Order> Orders { get; set; }
        public OrderDetail OrderDetail { get; set; }
        public List<OrderDetail> OrderDetails { get; set; }
    }
}