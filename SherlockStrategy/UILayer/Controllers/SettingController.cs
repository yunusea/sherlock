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
                var generalSettingBusiness = new GeneralSettingBusiness();
                var returnData = generalSettingBusiness.GetContractText();
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
                var generalSettingBusiness = new GeneralSettingBusiness();
                generalSettingBusiness.UpdateSetting(SingUpContractText);

                return View();
            }
            catch (Exception ex)
            {
                throw new NotSupportedException("Beklenmedik bir hata oluştu", ex);
            }
        }
    }
}