using BusinessLayer.Business;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace UILayer.Controllers
{
    public class SettingController : Controller
    {
        // GET: Setting
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
                    var _loginUserInfo = Session["Account"];
                    return View(_loginUserInfo);
                }
            }
            catch
            {
                return RedirectToAction("SingupAndSignin", "Account");
            }
        }

        public JsonResult GetContractText()
        {
            try
            {
                var contract = new UserBusiness();
                var returnData = contract.GetContractText();
                var ContractMessage = returnData.ContractText;
                return Json(ContractMessage, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                throw new NotSupportedException("Beklenmedik bir hata oluştu",ex);
            }
        }

        public ActionResult ContractTextUpdate(string SingUpContractText)
        {
            try
            {
                var setting = new SettingBusiness();
                setting.UpdateSetting(SingUpContractText);


                return View();
            }
            catch (Exception ex)
            {
                throw new NotSupportedException("Beklenmedik bir hata oluştu", ex);
            }
        }

    }
}