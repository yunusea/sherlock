using BusinessLayer.Business;
using Models.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Mvc;

namespace UILayer.Controllers
{
    public class UserController : Controller
    {
        // GET: User
        public ActionResult Index()
        {
            if (Session["Account"] == null)
            {
                return RedirectToAction("SingupAndSignin", "Account");
            }

            if (Session["AccountRol"].ToString() != "1")
            {
                return RedirectToAction("Index", "Home");
            }

            var _loginUserInfo = Session["Account"];
            return View(_loginUserInfo);
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
                    var _loginUserInfo = Session["Account"];
                    return View(_loginUserInfo);
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
                var user = new UserBusiness();

                var _listUsers = user.GetAllUserList();

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
                var user = new UserBusiness();

                user.UpdateProfile(UserName, Password, NewPassword);

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
                var user = new UserBusiness();


                user.DeleteUser(Entity);

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
                var user = new UserBusiness();

                Entity.Rol = 2;
                Entity.Status = false;
                Entity.SingUpContractStatus = true;
                user.AddUser(Entity);

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
                var user = new UserBusiness();

                user.ChangeStatu(Entity);

                return RedirectToAction("Index", "User");
            }
            catch (Exception ex)
            {
                return Json(ex.Message);
            }
        }
    }
}