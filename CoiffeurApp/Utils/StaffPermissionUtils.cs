using CoiffeurApp.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace CoiffeurApp.Utils
{
    public class StaffPermissionUtils
    {
        public void AddOrUpdate(StaffPermission staffPermission)
        {
            DbConnect db = new DbConnect();
            db.Entry(staffPermission).State = staffPermission.PermissionId != 0 ? EntityState.Modified : EntityState.Added;
            db.SaveChanges();
        }
        public void SoftDelete(int staffPermissionId)
        {
            DbConnect db = new DbConnect();
            var staffPermission = db.StaffPermission.FirstOrDefault(p => p.PermissionId == staffPermissionId && !p.IsDeleted);
            if (staffPermission != null)
            {
                staffPermission.IsDeleted = true;
            }
            db.SaveChanges();
        }
        public List<StaffPermission> GetStaffPermissionList()
        {
            DbConnect db = new DbConnect();
            List<StaffPermission> staffPermissionList = new List<StaffPermission>();
            staffPermissionList = db.StaffPermission.Include("User").Where(p=> !p.IsDeleted).ToList();
            return staffPermissionList;
        }
        public StaffPermission GetStaffPermission(int staffPermissionId)
        {
            DbConnect db = new DbConnect();
            var permission = db.StaffPermission.Include("User").FirstOrDefault(p => p.StaffId==p.User.UserId && p.PermissionId == staffPermissionId && !p.IsDeleted) ?? new StaffPermission();
            return permission;
        }
        public List<StaffPermission> GetStaffToStaffPermissionList(int Id)
        {
            DbConnect db = new DbConnect();
            List<StaffPermission> staffPermissionList = new List<StaffPermission>();
            staffPermissionList = db.StaffPermission.Include("User").Where(p => p.User.UserId == Id && !p.IsDeleted).ToList();
            return staffPermissionList;
        }
        public List<string> GetDate(int Id)
        {
            DbConnect db = new DbConnect();
            List<StaffPermission> permissionList = new List<StaffPermission>();
            permissionList = db.StaffPermission.Where(p => p.StaffId == Id).ToList();
            List<string> dateList = new List<string>();
            for (int i = 0; i < permissionList.Count; i++)
            {
                for (DateTime dt =permissionList[i].StartingDate; dt <= permissionList[i].EndingDate; dt = dt.AddDays(1))
                {
                    dateList.Add(dt.ToString("yyyy/MM/dd hh:mm"));
                }
            }
            
            return dateList;
        }
    }
}