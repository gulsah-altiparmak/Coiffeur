using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace CoiffeurApp
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {

            routes.MapRoute(name: "giris", url: "", defaults: new { controller = "User", action = "UserLoginView", UrlParameter.Optional });

            routes.MapRoute(name: "logOut", url: "cikis", defaults: new { controller = "User", action = "LogOut", UrlParameter.Optional });

            routes.MapRoute(name: "kullanici", url: "kullanici-islemleri/{id}", defaults: new { controller = "User", action = "UserView", UrlParameter.Optional });

            routes.MapRoute(name: "kullanici-browser", url: "kullanici-listesi", defaults: new { controller = "User", action = "UserBrowserView", UrlParameter.Optional });

            routes.MapRoute(name: "kullanici-delete", url: "kullanici-sil/{id}", defaults: new { controller = "User", action = "UserViewDelete", UrlParameter.Optional });

            routes.MapRoute(name: "kullanici-post", url: "kullanici-post/{id}", defaults: new { controller = "User", action = "UserView", UrlParameter.Optional });

            routes.MapRoute(name: "kullanici-register", url: "kullanici-kayit", defaults: new { controller = "User", action = "GetRegister", UrlParameter.Optional });

            routes.MapRoute(name: "hizmet", url: "hizmet-islemleri/{id}", defaults: new { controller = "Service", action = "ServiceView", UrlParameter.Optional });

            routes.MapRoute(name: "hizmet-browser", url: "hizmet-listesi", defaults: new { controller = "Service", action = "ServiceBrowserView", UrlParameter.Optional });

            routes.MapRoute(name: "hizmet-delete", url: "hizmet-sil/{id}", defaults: new { controller = "Service", action = "ServiceViewDelete", UrlParameter.Optional });

            routes.MapRoute(name: "randevu-delete", url: "randevu-sil/{id}", defaults: new { controller = "Book", action = "BookViewDelete", UrlParameter.Optional });

            routes.MapRoute(name: "randevu", url: "randevu-islemleri/{id}", defaults: new { controller = "Book", action = "GetBookView", UrlParameter.Optional });

            routes.MapRoute(name: "randevu-browser", url: "randevu-listesi", defaults: new { controller = "Book", action = "BookBrowserView", UrlParameter.Optional });

            routes.MapRoute(name: "personelIzin", url: "personelizin-islemleri/{id}", defaults: new { controller = "StaffPermission", action = "StaffPermissionView", UrlParameter.Optional });

            routes.MapRoute(name: "personelIzin-delete", url: "personelizin-sil/{id}", defaults: new { controller = "StaffPermission", action = "ViewDelete", UrlParameter.Optional });

            routes.MapRoute(name: "personelIzin-browser", url: "personelizin-listesi", defaults: new { controller = "StaffPermission", action = "StaffPermissionBrowserView", UrlParameter.Optional });

            routes.MapRoute(name: "randevuHizmetleri", url: "randevuHizmetleri-listesi", defaults: new { controller = "BookService", action = "BookServiceBrowserView", UrlParameter.Optional });

            routes.MapRoute(name: "randevu1", url: "randevu", defaults: new { controller = "Book", action = "GetStaffPermission", UrlParameter.Optional });


            routes.MapRoute(
                name: "Default",
                url: "dashboard",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
