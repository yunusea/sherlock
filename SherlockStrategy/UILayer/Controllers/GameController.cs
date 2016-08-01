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
            try
            {
                if (Session["Account"] == null)
                {
                    return RedirectToAction("SingupAndSignin", "Account");
                }
                else
                {
                    return View();
                }
            }
            catch
            {
                return RedirectToAction("SingupAndSignin", "Account");
            }
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

            try
            {
                if (Session["Account"] == null)
                {
                    return RedirectToAction("SingupAndSignin", "Account");
                }
                else
                {
                    var gameBusiness = new GameBusiness();
                    var game = gameBusiness.GetGameInfo(Id);
                    return View(game);
                }
            }
            catch
            {
                return RedirectToAction("SingupAndSignin", "Account");
            }
        }

        public JsonResult EncounterSave(int Et, int Id)
        {
            try
            {
                var gameBusiness = new GameBusiness();
                var playerId = Convert.ToInt32(Session["AccountId"]);
                gameBusiness.SaveEncounter(playerId, Et, Id);
                var Encounter = gameBusiness.GetEncounter(playerId, Id);

                return Json(Encounter,JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(ex, "Beklenmedik Bir Hata Oluştur");
            }
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

        public ActionResult OngoingGameList()
        {
            try
            {
                if (Session["Account"] == null)
                {
                    return RedirectToAction("SingupAndSignin", "Account");
                }
                else
                {
                    return View();
                }
            }
            catch
            {
                return RedirectToAction("SingupAndSignin", "Account");
            }
        }

        public JsonResult GetOngoingGameList()
        {
            try
            {
                var gameBusiness = new GameBusiness();
                var playerId = Convert.ToInt32(Session["AccountId"]);
                var ongoingGameList = gameBusiness.OngoingGameList(playerId);
                return Json(ongoingGameList, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(ex, "Devam Eden Oyun Listesi Getirilemedi !");
            }
        }

        public JsonResult SaveMove(int eId, string cellNameId)
        {
            try
            {
                var gameBusiness = new GameBusiness();
                var playerId = Convert.ToInt32(Session["AccountId"]);
                var returnMove = gameBusiness.SaveMove(eId, cellNameId);
               
                return Json(returnMove, JsonRequestBehavior.AllowGet);
             
            }
            catch (Exception ex)
            {
                return Json(ex, "Beklenmedik Bir Hata Oluştur");
            }
        }
    }
}