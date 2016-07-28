using BusinessLayer.Business;
using System;
using System.Collections.Generic;
using System.Linq;
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

        public ActionResult PlayGamePage()
        {
            return View();
        }

        public JsonResult GetPlayGamePage()
        {
            try
            {
                var gameBusiness = new GameBusiness();
                var gameBoard = gameBusiness.GetBoard();
                return Json(gameBoard, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(ex);
            }
        }

        public JsonResult ControlEndSet(int x1, int x2)
        {
            var d1 = x1;
            var d2 = x2;
            string er = "";
            var gameBusiness = new GameBusiness();
            var returnData = gameBusiness.CellControl(d1, d2);

            if (returnData)
            {
                gameBusiness.CellSet(1, d1, d2);
            }
            else
            {
                er = "Bu hücreyi seçemezsin !";
            }

            return Json(er, JsonRequestBehavior.AllowGet);
        }
    }
}