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
        public UserProfile UserProfile { get; set; }
    }
}