using System.Web.Mvc;
using System.Web.Routing;

namespace UILayer
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(name: "Anasayfa", url: "Anasayfa", defaults: new { Controller = "Home", action = "Index" });
            routes.MapRoute(name: "Kullanıcılar", url: "Kullanicilar", defaults: new { Controller = "User", action = "Index" });
            routes.MapRoute(name: "Profil", url: "Profil", defaults: new { Controller = "User", action = "Profil" });
            routes.MapRoute(name: "SingupAndSignin", url: "SingupAndSignin", defaults: new { Controller = "Account", action = "SingupAndSignin" });
            routes.MapRoute(name: "SingupContract", url: "SingupContract", defaults: new { Controller = "Account", action = "SingupContract" });
            routes.MapRoute(name: "SingupContractUpdate", url: "SingupContractUpdate", defaults: new { Controller = "Account", action = "SingupContractUpdateControl" });
            routes.MapRoute(name: "Ayarlar", url: "Ayarlar", defaults: new { Controller = "Setting", action = "Index" });
            routes.MapRoute(name: "MesajYaz", url: "MesajYaz/{Id}", defaults: new { Controller = "Message", action = "WriteMessage", Id = "" });
            routes.MapRoute(name: "GelenMesaj", url: "GelenMesaj", defaults: new { Controller = "Message", action = "InBox" });
            routes.MapRoute(name: "GidenMesaj", url: "GidenMesaj", defaults: new { Controller = "Message", action = "SendBox" });
            routes.MapRoute(name: "MesajOku", url: "MesajOku/{Id}", defaults: new { Controller = "Message", action = "ReadMessage", Id = "" });
            routes.MapRoute(name: "MesajCevapla", url: "MesajCevapla/{Id}", defaults: new { Controller = "Message", action = "ReplyMessage", Id = "" });
            routes.MapRoute(name: "Iletisim", url: "Iletisim", defaults: new { Controller = "Contact", action = "ContactForm" });
            routes.MapRoute(name: "IletisimMesajlari", url: "IletisimMesajlari", defaults: new { Controller = "Contact", action = "ContactFormMessage" });
            routes.MapRoute(name: "Oyunlar", url: "Oyunlar", defaults: new { Controller = "Game", action = "Index" });
            routes.MapRoute(name: "OyunOyna", url: "OyunOyna/{Id}", defaults: new { Controller = "Game", action = "PlayGamePage", Id="" });
            routes.MapRoute(name: "DevamEdenOyunlar", url: "DevamEdenOyunlar", defaults: new { Controller = "Game", action = "OngoingGameList" });
            routes.MapRoute(name: "OyunaDevamEt", url: "OyunaDevamEt/{Id}", defaults: new { Controller = "Game", action = "ContinueGame", Id = "" });
            
            routes.MapRoute(name: "Default", url: "{controller}/{action}/{id}", defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional });
        }
    }
}
