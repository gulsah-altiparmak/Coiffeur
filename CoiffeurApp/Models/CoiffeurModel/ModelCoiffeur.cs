using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CoiffeurApp.Models.CoiffeurModel
{
    public class ModelCoiffeur
    {
        public User User { get; set; }
        public List<User> UserList { get; set; }
       

        public BookService BookService { get; set; }
        public List<BookService> BookServiceList { set; get; }

        public Service Service { get; set; }
        public List<Service> ServiceList { get; set; }

        public Book Book { get; set; }
        public List<Book> BookList { get; set; }
        
        public List<User> CustomerList { get; set; }
        public List<User> StaffList { get; set; }

        public StaffPermission StaffPermission { get; set; }
        public List<StaffPermission> StaffPermissionList { get; set; }

        [RegularExpression(@"([a-zA-Z0-9\s_\\.\-:])+(.png|.jpg|.gif|.ico)$", ErrorMessage = "Sadece görsel dosyaları geçerlidir.")]
        public HttpPostedFileBase PostedFile { get; set; }

        [RegularExpression(@"([a-zA-Z0-9\s_\\.\-:])+(.png|.jpg|.gif|.ico)$", ErrorMessage = "Sadece görsel dosyaları geçerlidir.")]
        public List<HttpPostedFileBase> GeneralImages { get; set; }
    }
}