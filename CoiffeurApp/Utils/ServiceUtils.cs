using CoiffeurApp.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;


namespace CoiffeurApp.Utils
{
    public class ServiceUtils
    {
        public List<Service> GetServiceList()
        {
            DbConnect db = new DbConnect();
            List<Service> serviceList = new List<Service>();
            serviceList = db.Service.Where(p => !p.IsDelete).ToList();
            return serviceList;
        }
        public Service GetService(int serviceId)
        {
            DbConnect db = new DbConnect();
            var service = db.Service.FirstOrDefault(p => !p.IsDelete && p.ServiceId == serviceId) ?? new Service();
            return service;
        }
        public void SoftDelete(int serviceId)
        {
            DbConnect db = new DbConnect();
            var service = db.Service.FirstOrDefault(p => !p.IsDelete && p.ServiceId == serviceId);
            if (service != null)
            {
                service.IsDelete = true;
              
            }
            db.SaveChanges();
        }
        public void AddOrUpdate(Service service)
        {
            DbConnect db = new DbConnect();
            db.Entry(service).State = service.ServiceId != 0 ? EntityState.Modified : EntityState.Added;
            db.SaveChanges();
        }
     


    }
}