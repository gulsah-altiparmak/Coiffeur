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
    [LoginFilter]
    public class BookController : Controller
    {

        private readonly BookUtils bookUtils = new BookUtils();
        private readonly ServiceUtils serviceUtils = new ServiceUtils();
        private readonly UserUtils userUtils = new UserUtils();
        private readonly StaffPermissionUtils staffPermissionUtils = new StaffPermissionUtils();
        // GET: Book

        public ActionResult BookBrowserView()
        {
            ModelCoiffeur modelCoiffeur = new ModelCoiffeur();
            var user = (User)Session["User"];
            if (user.Type.Equals("admin") )
            {
                modelCoiffeur.BookList = bookUtils.GetBookList();
            }
            else if (user.Type.Equals("personel"))
            {
                modelCoiffeur.BookList = bookUtils.GetBookList().Where(p => p.StaffId.Equals(user.UserId)).ToList();
            }
            else
            {
                modelCoiffeur.BookList = bookUtils.GetBookList().Where(p => p.UserId.Equals(user.UserId)).ToList();
            }


            return View(modelCoiffeur);
        }
        public JsonResult BookViewDelete(int Id)
        {
            bool data = true;
            bookUtils.SoftDelete(Id);
            return Json(data);
        }
        [HttpGet]
        public ActionResult GetBookView(int id)
        {
            int bookId = id;
            ModelCoiffeur modelCoiffeur = new ModelCoiffeur();
            var book = bookUtils.GetBook(bookId);
            modelCoiffeur.Book = book;
            if (modelCoiffeur.Book.bookServices == null)
                modelCoiffeur.Book.bookServices = new List<Models.BookService>();

            var user = (User)Session["User"];
            if (user.Type.Equals("admin") || user.Type.Equals("personel"))
            {
                modelCoiffeur.CustomerList = userUtils.GetCustomer();
            }
            else
            {
                modelCoiffeur.CustomerList = userUtils.GetCustomer().Where(p => p.UserId.Equals(user.UserId)).ToList();
            }

            modelCoiffeur.StaffList = userUtils.GetStaff();
            

            DbConnect connect = new DbConnect();
            var list = connect.BookService.Where(p => p.BookId == bookId && !p.IsDeleted).ToList();

            var serviceList = serviceUtils.GetServiceList();

          
            foreach (var bookService in list)
            {
               var item = serviceList.FirstOrDefault(p => p.ServiceId == bookService.ServiceId);
                if(item != null)
                {
                    serviceList.FirstOrDefault(p => p.ServiceId == bookService.ServiceId).IsChecked = true;
                    
                }
            }
       
            modelCoiffeur.ServiceList = serviceList;
            return View(modelCoiffeur);
        }

        [HttpPost]
        public ActionResult GetBookView(ModelCoiffeur model)
        {
            var book = model.Book;
            var services = model.ServiceList.Where(p => p.IsChecked).ToList();
            book.bookServices = new List<BookService>();
            var addedBook = bookUtils.AddOrUpdate(book);

            DbConnect connect = new DbConnect();
            var list = connect.BookService.Where(p => p.BookId == addedBook.BookId && !p.IsDeleted).ToList();
            BookServiceUtils bookServiceUtils = new BookServiceUtils();

            foreach (var bookService in list)
            {
                bookService.IsDeleted = true;
                bookServiceUtils.AddOrUpdate(bookService);
            }


            foreach (var service in services)
            {
                BookService bookService = new BookService()
                {
                    ServiceId = service.ServiceId,
                    IsDeleted = false,
                    BookId = addedBook.BookId
                };
                bookServiceUtils.AddOrUpdate(bookService);
            }


            return RedirectToAction("GetBookView", "Book");
        }
     
        [HttpGet]
        public JsonResult GetStaffPermission(int Id)
        {
            var list = staffPermissionUtils.GetDate(Id);
            return Json(list, JsonRequestBehavior.AllowGet);

        }
    }
}