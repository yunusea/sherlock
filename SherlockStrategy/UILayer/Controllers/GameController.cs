using BusinessLayer.Business;
using Models.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;
using UILayer.ViewModel;

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
                return Json(ex, "Beklenmedik Bir Hata Oluştu !");
            }
        }

        public ActionResult PlayGamePage(int Id)
        {
            var gameBusiness = new GameBusiness();
            var game = gameBusiness.GetGameInfo(Id);
            return View(game);
        }

        public JsonResult GetGameInfo(int Id)
        {
            try
            {
                var gameBuseiness = new GameBusiness();
                var gameInfo = gameBuseiness.GetGameInfo(Id);
                return Json(gameInfo, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(ex);
            }
        }

        public JsonResult ControlEndSet(int x1, int x2)
        {
            string er = "";
            var gameBusiness = new GameBusiness();
            var returnData = gameBusiness.CellControl(x1, x2);

            if (returnData)
            {
                gameBusiness.SaveHandle(1, x1, x2);
            }
            else
            {
                er = "Bu hücreyi seçemezsin !";
            }

            return Json(er, JsonRequestBehavior.AllowGet);
        }
    }
}