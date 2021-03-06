﻿using PagedList;
using Project.ENTITIES.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Project.WebUI.Models.VMClasses
{
    public class AppUserVM
    {
        public AppUser AppUser { get; set; }
        public List<AppUser> AppUsers { get; set; }
        public IPagedList<AppUser> PagedAppUsers { get; set; }
        public UserProfile UserProfile { get; set; }
        public List<Order> Orders { get; set; }
        public IPagedList<Order> PagedOrders { get; set; }
        public Order Order { get; set; }
        public List<UserProfile> UserProfiles { get; set; }
    }
}