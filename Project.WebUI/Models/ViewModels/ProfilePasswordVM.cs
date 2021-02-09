using Project.WebUI.Models.VMClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Project.WebUI.Models.ViewModels
{
    public class ProfilePasswordVM
    {
        public AppUserVM AppUserVM { get; set; }
        public ChangePasswordVM ChangePasswordVM { get; set; }
    }
}