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

    public class UserController : Controller
    {
        private readonly UserUtils userUtils = new UserUtils();
        private readonly ImageUtils imageUtils = new ImageUtils();

        [HttpPost]
        public ActionResult UserLoginView(User userLogin)
        {
            var user = userUtils.GetLogin(userLogin);
            if (user != null)
            {
                Session["User"] = user;
                ViewBag.userName = user.UserName;
                Session["UserType"] = user.Type;
                Session["UserId"] = user.UserId;

                return RedirectToAction("Index", "Home");

            }
            else
            {
                ModelState.AddModelError("", "Kullanıcı adı veya şifre hatalı");
                return RedirectToAction("UserLoginView");

            }

        }

        [HttpGet]
        public ActionResult UserLoginView()
        {
            User userLogin = new User();
            return View(userLogin);
        }

        public ActionResult LogOut()
        {
            Session.Clear();
            return RedirectToAction("UserLoginView", "User");
        }



        [HttpPost]
        public ActionResult GetRegister(User user)
        {
            var IsUser = userUtils.IsRegister(user);
            if (IsUser == true)
            {
                userUtils.AddOrUpdate(user);
                Session["User"] = user;
                Session["UserType"] = user.Type;
                return RedirectToAction("Index", "Home");
            }
            return RedirectToAction("UserLoginView", "User");
        }

        [HttpGet]
        public ActionResult UserView(int Id)
        {
            if (Session["User"] == null)
            {
                return RedirectToAction("UserLoginView", "User");
            }
            else
            {
                var user = (User)Session["User"];
                ModelCoiffeur modelCoiffeur = new ModelCoiffeur();
                if (Session["UserType"].Equals("admin"))
                {

                    modelCoiffeur.User = userUtils.GetUser(Id);
                    return View(modelCoiffeur);
                }

                modelCoiffeur.User = userUtils.AddOrUpdate(user);
                return View(modelCoiffeur);

            }

        }

        [HttpPost]
        public ActionResult UserView(ModelCoiffeur modelCoiffeur)
        {
            try
            {
                var user = modelCoiffeur.User;
                if (user.Type == null)
                    user.Type = "personel";
                userUtils.AddOrUpdate(user);
            }
            catch (Exception ex)
            {
                Session["error"] = ex.Message.ToString();
                return RedirectToAction("ExceptionView", "Exception");
            }

            return RedirectToAction("UserBrowserView", "User");
        }

        public ActionResult UserBrowserView()
        {

            ModelCoiffeur modelCoiffeur = new ModelCoiffeur();
            modelCoiffeur.UserList = userUtils.GetUserList();
            return View(modelCoiffeur);
        }

        public JsonResult UserViewDelete(int Id)
        {
            bool data = true;
            userUtils.SoftDelete(Id);
            return Json(data);
        }

        public string UploadImages(List<HttpPostedFileBase> file)
        {
            string result = "";
            try
            {
                string path = Server.MapPath("~/Uploads/");
                string fileName = "";
                var postedFile = file[0];
                if (postedFile != null)
                    imageUtils.GetImageList(path, fileName, postedFile);

            }
            catch (Exception ex)
            {

                result = "Hata oluştu";
            }
            return result;
        }

    }
}