using Project.ENTITIES.Models;
using Project.WebUI.Models.ShoppingTools;
using Project.WebUI.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Project.WebUI.Models.VMClasses
{
    public class OrderVM
    {
        public PaymentVM PaymentVM { get; set; }
        public Order Order { get; set; }

        
        //public AppUser AppUser { get; set; }
        //public UserProfile UserProfile { get; set; }
        //public Cart Cart { get; set; } 
        //public CartItem CartItem { get; set; }
    }
}