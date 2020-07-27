using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CoiffeurApp.Controllers
{
    public class ExceptionController : Controller
    {
        // GET: Exception
        public ActionResult ExceptionView()
        {
            return View();
        }
    }
}