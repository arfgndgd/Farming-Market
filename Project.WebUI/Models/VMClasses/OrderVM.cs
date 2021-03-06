﻿using PagedList;
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
        public List<Order> Orders { get; set; }
        public List<AppUser> AppUsers { get; set; }
        public List<Shipper> Shippers { get; set; }
        public IPagedList<Order> PagedOrders { get; set; }
        public IPagedList<OrderDetail> PagedOrderDetails { get; set; }




        public AppUser AppUser { get; set; }
        public UserProfile UserProfile { get; set; }
        //public Cart Cart { get; set; } 
        //public CartItem CartItem { get; set; }
    }
}