using BusinessLayer.Business;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UILayer.ViewModel;

namespace UILayer.Controllers
{
    public class MessageController : Controller
    {
        public ActionResult GetWriteMessageData(int Id)
        {
            var user = new UserBusiness();
            var ReceiverUserInfo = user.GetUserInfo(Id);
            var SenderUserInfo = user.GetUserInfo((int)Session["AccountId"]);
            var WriteMessageWM = new WriteMessageViewModel()
            {
                SenderName = SenderUserInfo.UserName,
                ReceiverName = ReceiverUserInfo.UserName
            };

            return Json(WriteMessageWM, JsonRequestBehavior.AllowGet);

        }

        public ActionResult WriteMessage()
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

    }
}