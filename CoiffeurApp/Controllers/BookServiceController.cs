using CoiffeurApp.Filter;
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
    public class BookServiceController : Controller
    {
       
        private readonly BookServiceUtils bookServiceUtils = new BookServiceUtils();
        // GET: BookService
        public ActionResult BookServiceBrowserView()
        {
            ModelCoiffeur modelCoiffeur = new ModelCoiffeur();
            modelCoiffeur.BookServiceList = bookServiceUtils.GetDateServiceList();
            return View(modelCoiffeur);
        }
    }
}