using CoiffeurApp.Filter;
using CoiffeurApp.Models;
using CoiffeurApp.Models.CoiffeurModel;
using CoiffeurApp.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CoiffeurApp.Controllers
{
    [ExceptionFilter, LoginFilter]
    public class HomeController : Controller
    {
        // GET: Home
    
      
        public ActionResult Index()

        {
            return View();
        }
      
       
     
    }
}