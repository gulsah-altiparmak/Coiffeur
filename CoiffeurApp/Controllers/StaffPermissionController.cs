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
    public class StaffPermissionController : Controller
    {
        private readonly StaffPermissionUtils staffPermissionUtils = new StaffPermissionUtils();
        private readonly UserUtils userUtils = new UserUtils();
        // GET: StaffPermission
        [HttpGet]
        public ActionResult StaffPermissionView(int Id)
        {
            ModelCoiffeur modelCoiffeur = new ModelCoiffeur();
            modelCoiffeur.StaffPermission = staffPermissionUtils.GetStaffPermission(Id);
            modelCoiffeur.StaffList = userUtils.GetStaff();
            return View(modelCoiffeur);
        }
        [HttpPost]
        public ActionResult StaffPermissionView(ModelCoiffeur modelCoiffeur)
        {
            try
            {
                var staffPermission = modelCoiffeur.StaffPermission;
                staffPermissionUtils.AddOrUpdate(staffPermission);
            }
            catch (Exception ex)
            {

                Session["error"] = ex.Message.ToString();
                return RedirectToAction("ExceptionView", "Exception");
            }
            return RedirectToAction("StaffPermissionBrowserView", "StaffPermission");
        }

        public ActionResult StaffPermissionBrowserView()
        {
            var user = (User)Session["User"];
            ModelCoiffeur modelCoiffeur = new ModelCoiffeur();
            if (user.Type.Equals("admin"))
            {
            modelCoiffeur.StaffPermissionList = staffPermissionUtils.GetStaffPermissionList();
            }
            else if(user.Type.Equals("personel"))
            {
           
                modelCoiffeur.StaffPermissionList = staffPermissionUtils.GetStaffToStaffPermissionList(user.UserId);
            }
            return View(modelCoiffeur);
        }
        public JsonResult ViewDelete(int Id)
        {
            bool data = true;
            staffPermissionUtils.SoftDelete(Id);
            return Json(data);
        }

   
    }
}