using BusinessLayer.Business;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace UILayer.Controllers
{
    public class GameController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public JsonResult GetGameList()
        {
            try
            {
                var gameBusiness = new GameBusiness();
                var gameList = gameBusiness.GetAllGameList();

                return Json(gameList, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(ex,"Beklenmedik Bir Hata Oluştu !");
            }
        }

        public ActionResult PlayGamePage()
        {
            return View();
        }
    }
}