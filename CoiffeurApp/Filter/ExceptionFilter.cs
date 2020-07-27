using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CoiffeurApp.Filter
{
    public class ExceptionFilter : FilterAttribute, IExceptionFilter
    {
        public void OnException(ExceptionContext filterContext)
        {
            if (!filterContext.ExceptionHandled)
            {
                Exception e = filterContext.Exception;
                filterContext.ExceptionHandled = true;
                filterContext.Result = new RedirectResult("/hata");
            }
        }
    }
}