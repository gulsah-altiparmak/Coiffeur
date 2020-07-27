using CoiffeurApp.Models;
using CoiffeurApp.Models.ResponseModel;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace CoiffeurApp.Utils
{
    public class BookServiceUtils
    {
        public List<BookService> GetDateServiceList()
        {
            DbConnect db = new DbConnect();
            List<BookService> dateServiceList = new List<BookService>();
            dateServiceList = db.BookService.Include("Service").Include("Book").Where(p =>!p.IsDeleted).ToList();
            return dateServiceList;
        }

       
        public void AddOrUpdate(BookService bookService)
        {
            DbConnect db = new DbConnect();
            db.Entry(bookService).State = bookService.BookServiceId != 0 ? EntityState.Modified : EntityState.Added;
            db.SaveChanges();

        }
    
    
    }
}