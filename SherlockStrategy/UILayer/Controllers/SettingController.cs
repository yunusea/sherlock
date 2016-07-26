using BusinessLayer.Business;
using System;
using System.Web.Mvc;

namespace UILayer.Controllers
{
    public class SettingController : Controller
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