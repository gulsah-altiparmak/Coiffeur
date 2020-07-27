using CoiffeurApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CoiffeurApp.Filter
{
    public class LoginFilter : FilterAttribute, IAuthorizationFilter
    {
        public void OnAuthorization(AuthorizationContext filterContext)
        {
            User user = (User)HttpContext.Current.Session["User"];
            if (user == null)
            {
                filterContext.Result = new RedirectResult("");
            }
        }
    }
}