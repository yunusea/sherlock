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
                var Encounter = gameBusiness.GetEncounterByPlayerId(playerId, Id);

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
                List<OngoingGameViewModel> OngoingGameVMList = new List<OngoingGameViewModel>();

                for (int i = 0; i < ongoingGameList.Count; i++)
                {
                    OngoingGameViewModel OngoingGameVM = new OngoingGameViewModel();
                    var game = gameBusiness.GetGameInfo(ongoingGameList[i].GameId);

                    OngoingGameVM.GameName = game.GameName;
                    OngoingGameVM.OngoingGameId = ongoingGameList[i].Id;
                    if (ongoingGameList[i].EncounterType == 1)
                    {
                        OngoingGameVM.EncounterTypeName = "Bilgisayara Karşı";
                    }
                    else if(ongoingGameList[i].EncounterType == 2)
                    {
                        OngoingGameVM.EncounterTypeName = "Oyuncuya Karşı";
                    }
                    OngoingGameVMList.Add(OngoingGameVM);
                }

                return Json(OngoingGameVMList, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(ex, "Devam Eden Oyun Listesi Getirilemedi !");
            }
        }

        public ActionResult ContinueGame(int Id)
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
                    var encounterGame = gameBusiness.GetEncounterById(Id);
                    var game = gameBusiness.GetGameInfo(encounterGame.GameId);
                    var continueGameVM = new ContinueGameViewModel()
                    {
                        Game = game,
                        EncounterArchive = encounterGame
                    };
                    return View(continueGameVM);
                }
            }
            catch
            {
                return RedirectToAction("SingupAndSignin", "Account");
            }
        }

        public JsonResult GetCotinueGame(int Id)
        {
            var gameBusiness = new GameBusiness();
            var encounter = gameBusiness.GetEncounterById(Id);
            var game = gameBusiness.GetGameInfo(encounter.GameId);
            return Json(game, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetLabeledCell(int Id)
        {
            var gameBusiness = new GameBusiness();
            List<MoveArchive> moves = gameBusiness.GetMoveListByEncounter(Id);
            return Json(moves, JsonRequestBehavior.AllowGet);
        }

        public JsonResult SaveMove(int eId, int MoveCellx, int MoveCelly, string Value)
        {
            try
            {
                var gameBusiness = new GameBusiness();
                var playerId = Convert.ToInt32(Session["AccountId"]);
                var returnMove = gameBusiness.SaveMove(eId, MoveCellx, MoveCelly, Value);
               
                return Json(returnMove, JsonRequestBehavior.AllowGet);
             
            }
            catch (Exception ex)
            {
                return Json(ex, "Beklenmedik Bir Hata Oluştur");
            }
        }

        public JsonResult EncounterUpdate(int eId, int winnerInfo)
        {
            try
            {
                int winnerType;
                var gameBusiness = new GameBusiness();
                if(winnerInfo == 1)
                {
                    winnerType = 1;
                }
                else if(winnerInfo == 2)
                {
                    winnerType = 2;
                }
                else if (winnerInfo == 3)
                {
                    winnerType = 3;
                }
                else
                {
                    winnerType = 0;
                }
                gameBusiness.UpdateEncounter(eId, winnerType);
                return Json("");
            }
            catch (Exception ex)
            {
                throw new NotSupportedException("Beklenmedik Bir Hata Oluştu !", ex);
            }
        }
    }
}