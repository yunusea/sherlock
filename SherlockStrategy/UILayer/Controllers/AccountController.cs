﻿using BusinessLayer;
using BusinessLayer.Business;
using Models.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace UILayer.Controllers
{
    public class AccountController : Controller
    {
        public ActionResult SingupAndSignin()
        {
            if (Session["Account"] != null)
            {
                return RedirectToAction("Index", "Home");
            }
            return View();
        }

        public ActionResult SingupContract()
        {
            if (Session["Account"] != null)
            {
                return RedirectToAction("Index", "Home");
            }
            return View();
        }

        public JsonResult GetSingupContract()
        {
            var contract = new UserBusiness();
            var returnData = contract.GetContractText();
            var ContractMessage = returnData.ContractText;
            return Json(ContractMessage, JsonRequestBehavior.AllowGet);
        }

        public ActionResult Login(string UserName, string Password)
        {
            if (Session["Account"] != null)
            {
                return RedirectToAction("Index", "Home");
            }

            try
            {
                var user = new UserBusiness();

                //Kullanıcı giriş bilgilerini girdi ve giriş yap dedi.
                var _loginUser = user.GetLoginUser(UserName, Password);

                //giriş yap butonuna bastıktan sonra kullanıcının bilgisi döndü
                if (_loginUser == null)
                {
                    var message = "Giriş işlemi başarılı değil !";
                    return Json(message, JsonRequestBehavior.AllowGet);
                }

                if (_loginUser.Status == false)
                {
                    var message = "Giriş işlemi yapabilmeniz için yönetici tarafından üyeliğinizin onaylanması gerekiyor !";
                    return Json(message, JsonRequestBehavior.AllowGet);
                }

                if (_loginUser.SingUpContractStatus == false)
                {
                    Session["SleepAccount"] = _loginUser;
                    return Json(_loginUser, JsonRequestBehavior.AllowGet);
                }

                //Giriş yapan kullanıcının kaydı olduğu için giriş işlemi başarılı oldu.
                Session["Account"] = _loginUser;
                Session["AccountId"] = _loginUser.Id;
                Session["AccountRol"] = _loginUser.Rol;


                //Giriş başarılı olduğu için giriş yapan kullanıcının bilgileri Json il
                return Json(_loginUser, JsonRequestBehavior.AllowGet);

            }
            catch (Exception ex)
            {
                return Json(ex.Message);
            }
        }

        public JsonResult Logout()
        {
            try
            {
                Session.Abandon();
                var message = "Çıkış Yapıldı";
                return Json(message, JsonRequestBehavior.AllowGet);

            }
            catch (Exception ex)
            {
                return Json(ex.Message);
            }
        }

        public ActionResult SingupContractUpdateControl()
        {
            try
            {
                if (Session["Account"] == null)
                {
                    if (Session["SleepAccount"] != null)
                    {
                        var _loginUserInfo = Session["SleepAccount"];
                        return View(_loginUserInfo);
                    }
                    else
                    {
                        return RedirectToAction("SingupAndSignin", "Account");
                    }
                }
                else
                {
                    return RedirectToAction("SingupAndSignin", "Account");
                }
            }
            catch
            {
                return RedirectToAction("SingupAndSignin", "Account");
            }
        }

        public ActionResult SingUpContractUpdateControlChecked()
        {
            if (Session["SleepAccount"] == null)
            {
                return RedirectToAction("SingupAndSignin", "Account");
            }

            var _loginUserInfo = Session["SleepAccount"];

            Session["Account"] = _loginUserInfo;

            if (Session["Account"] == null)
            {
                return RedirectToAction("SingupAndSignin", "Account");
            }

            var propInfo = _loginUserInfo.GetType().GetProperty("Id");
            int Id = (int)propInfo.GetValue(_loginUserInfo);
            var user = new UserBusiness();
            var resultUser = user.UpdateContractTextChecked(Id);

            return Json(resultUser, JsonRequestBehavior.AllowGet);
        }
    }
}