using BusinessLayer.Business;
using Models.Model;
using System;
using System.Web.Mvc;

namespace UILayer.Controllers
{
    public class UserController : Controller
    {
        public ActionResult Index()
        {
            if (Session["Account"] == null)
            {
                return RedirectToAction("SingupAndSignin", "Account");
            }
            return View();
        }

        public ActionResult Profil()
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

        public ActionResult GetProfilInfo()
        {
            try
            {
                if (Session["Account"] == null)
                {
                    return RedirectToAction("SingupAndSignin", "Account");
                }
                
                var _loginUserInfo = Session["Account"];
                var result = Json(_loginUserInfo, JsonRequestBehavior.AllowGet);
                return result;
            }
            catch (Exception ex)
            {
                return Json(ex.Message);
            }
        }

        public JsonResult GetUserList()
        {
            try
            {
                var userBusiness = new UserBusiness();

                var _listUsers = userBusiness.GetAllUserList();

                var result = Json(_listUsers, JsonRequestBehavior.AllowGet);

                return result;
            }
            catch (Exception ex)
            {
                return Json(ex.Message);
            }
        }

        public ActionResult UserUpdate(string UserName, string Password, string NewPassword)
        {
            try
            {
                var userBusiness = new UserBusiness();

                userBusiness.UpdateProfile(UserName, Password, NewPassword);

                return RedirectToAction("GetUserList", "Account");
            }
            catch (Exception ex)
            {
                return Json(ex.Message);
            }
        }

        public ActionResult DeleteUser(User Entity)
        {
            try
            {
                var userBusiness = new UserBusiness();

                userBusiness.DeleteUser(Entity);

                return RedirectToAction("GetUserList", "Account");
            }
            catch (Exception ex)
            {
                return Json(ex.Message);
            }
        }

        public ActionResult SaveUser(User Entity)
        {
            try
            {
                var userBusiness = new UserBusiness();

                Entity.Rol = 2;
                Entity.Status = false;
                Entity.SingUpContractStatus = true;
                userBusiness.AddUser(Entity);

                return RedirectToAction("SingupAndSignin", "Account");
            }
            catch (Exception ex)
            {
                return Json(ex.Message);
            }
        }

        public ActionResult ChangeStatu(User Entity)
        {
            try
            {
                var userBusiness = new UserBusiness();

                userBusiness.ChangeStatu(Entity);

                return RedirectToAction("Index", "User");
            }
            catch (Exception ex)
            {
                return Json(ex.Message);
            }
        }
    }
}