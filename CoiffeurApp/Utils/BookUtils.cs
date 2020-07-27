using CoiffeurApp.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace CoiffeurApp.Utils
{
    public class BookUtils
    {
        public Book AddOrUpdate(Book book)
        {
            DbConnect db = new DbConnect();
            db.Entry(book).State = book.BookId != 0 ? EntityState.Modified : EntityState.Added;
            db.SaveChanges();
            return book;
        }
        public void SoftDelete(int bookId)
        {
            DbConnect db = new DbConnect();
            var date = db.Book.FirstOrDefault(p => p.BookId == bookId && p.UserId == p.User.UserId && p.UserId == p.Staff.UserId && !p.IsDeleted);
            if (date != null)
            {
                date.IsDeleted = true;
            }
            db.SaveChanges();
        }
        public List<Book> GetBookList()
        {
            DbConnect db = new DbConnect();
            List<Book> dateList = new List<Book>();
            dateList = db.Book.Include("User").Where(p => !p.IsDeleted).ToList();
            return dateList;
        }

        public Book GetBook(int bookId)
        {
            DbConnect db = new DbConnect();
            var book = db.Book.FirstOrDefault(p => p.BookId == bookId && !p.IsDeleted) ?? new Book();
            return book;
        }
        //public List<Book> GetStaffBookList(int Id)
        //{
        //    DbConnect db = new DbConnect();
        //    List<Book> bookList = new List<Book>();
        //    bookList = db.Book.Where(p => p.StaffId == Id && !p.IsDeleted).OrderByDescending(p=>p.StartingDate).ToList();
        //    return bookList;
        //}
        //public List<Book> GetCustomerBookList(int Id)
        //{
        //    DbConnect db = new DbConnect();
        //    List<Book> bookList = new List<Book>();
        //    bookList = db.Book.Where(p => p.UserId == Id && !p.IsDeleted).OrderByDescending(p => p.StartingDate).ToList();
        //    return bookList;
        //}
     
    }
}