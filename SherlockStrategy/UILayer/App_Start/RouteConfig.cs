using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace UILayer
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(name : "Anasayfa", url: "Anasayfa", defaults: new { Controller  = "Home", action = "Index"});
            routes.MapRoute(name : "Kullanıcılar", url: "Kullanicilar", defaults: new { Controller  = "User", action = "Index"});
            routes.MapRoute(name : "SingupAndSignin", url: "SingupAndSignin", defaults: new { Controller  = "Account", action = "SingupAndSignin" });
            routes.MapRoute(name : "SingupContract", url: "SingupContract", defaults: new { Controller  = "Account", action = "SingupContract" });

            routes.MapRoute(name: "Default",url: "{controller}/{action}/{id}",defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional });
        }
    }
}
