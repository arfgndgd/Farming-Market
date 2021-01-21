using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Project.WebUI.AuthenticationClasses
{
    public class ManagerAuthentication:AuthorizeAttribute
    {
        protected override bool AuthorizeCore(HttpContextBase httpContext)
        {
            if (httpContext.Session["manager"]!=null)
            {
                return true;
            }
            httpContext.Response.Redirect("/Account/Login");
            return false;
        }
    }
}