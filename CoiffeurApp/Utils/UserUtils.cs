using CoiffeurApp.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace CoiffeurApp.Utils
{
    public class UserUtils
    {
        public BookUtils bookUtils = new BookUtils();
        public List<User> GetUserList()
        {
            DbConnect db = new DbConnect();
            List<User> userList = new List<User>();
            userList = db.User.Where(p =>!p.IsDelete).ToList();

            return userList;
        }

        public User GetUser(int userId)
        {
            DbConnect db = new DbConnect();
            var user = db.User.FirstOrDefault(p => p.UserId == userId && !p.IsDelete)?? new User();
            return user;
        }
        public void SoftDelete(int userId)
        {
            DbConnect db = new DbConnect();
            var delete = db.User.FirstOrDefault(p => !p.IsDelete && p.UserId == userId);
          
            if (delete != null)
            {
                delete.IsDelete = true;
            }
            db.SaveChanges();
        }
        public User AddOrUpdate(User user)
        {
            DbConnect db = new DbConnect();

            db.Entry(user).State = user.UserId != 0 ? EntityState.Modified : EntityState.Added;

            db.SaveChanges();
            return user;

        }
        public User GetLogin(User userLogin)
        {
            DbConnect db = new DbConnect();
            var user = db.User.FirstOrDefault(p => p.UserName == userLogin.UserName && p.Password == userLogin.Password && !p.IsDelete);
            return user;
        }
        public bool IsRegister(User user)
        {
            DbConnect db = new DbConnect();
            var register = db.User.FirstOrDefault(p => p.UserName == user.UserName && !p.IsDelete);
            if (register == null)
            {
                return true;
            }
            return false;
        }

        public List<User> GetStaff()
        {
            DbConnect db = new DbConnect();
            List<User> staffList = new List<User>();
            staffList = db.User.Where(p => !p.IsDelete && p.Type.Equals("personel")).ToList();
            return staffList;
        }
        public List<User> GetCustomer()
        {
            DbConnect db = new DbConnect();
            List<User> customerList = new List<User>();
            customerList = db.User.Where(p => !p.IsDelete && p.Type.Equals("musteri")).ToList();
            return customerList;
        }
    
    }
}