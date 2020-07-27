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
    [ LoginFilter]
    public class ServiceController : Controller
    {
        private readonly ServiceUtils serviceUtils = new ServiceUtils();
        private readonly ImageUtils imageUtils = new ImageUtils();
        // GET: Service
        [HttpGet]
        public ActionResult ServiceView(int Id)
        {
            ModelCoiffeur modelCoiffeur = new ModelCoiffeur();
            modelCoiffeur.Service = serviceUtils.GetService(Id);
            return View(modelCoiffeur);
        }

        public ActionResult ServiceBrowserView()
        {
            ModelCoiffeur modelCoiffeur = new ModelCoiffeur();
            modelCoiffeur.ServiceList = serviceUtils.GetServiceList();
            return View(modelCoiffeur);
        }
        [HttpPost]
        public ActionResult ServiceView(ModelCoiffeur modelCoiffeur)
        {
            try
            {

                var service = modelCoiffeur.Service;
                serviceUtils.AddOrUpdate(service);
            }
            catch (Exception ex)
            {

                Session["error"] = ex.Message.ToString();
                return RedirectToAction("ExceptionView", "Exception");
            }


            return RedirectToAction("ServiceBrowserView", "Service");
        }
        public JsonResult ServiceViewDelete(int Id)
        {
            bool data = true;
            serviceUtils.SoftDelete(Id);
            return Json(data);
        }

    
    }
}