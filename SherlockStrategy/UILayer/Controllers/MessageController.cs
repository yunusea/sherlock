using BusinessLayer.Business;
using Models.Model;
using System;
using System.Web.Mvc;
using UILayer.ViewModel;

namespace UILayer.Controllers
{
    public class MessageController : Controller
    {
        public ActionResult InBox()
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

        public ActionResult SendBox()
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

        public JsonResult GetUserInBox()
        {
            try
            {
                var messagebusiness = new MessageBusiness();

                var Id  = Convert.ToInt32(Session["AccountId"]);
                var messageList = messagebusiness.GetUserInBoxMessages(Id);

                return Json(messageList, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                throw new NotSupportedException("Beklenmedik bir hata oluştu !", ex);
            }
        }

        public ActionResult DeleteMessage(Message Entity)
        {
            try
            {
                var messagebusiness = new MessageBusiness();


                messagebusiness.DeleteMessage(Entity);

                return RedirectToAction("GetUserInBox", "Message");
            }
            catch (Exception ex)
            {
                return Json(ex.Message);
            }
        }

        public JsonResult GetUserSendBox()
        {
            try
            {
                var messagebusiness = new MessageBusiness();

                var Id = Convert.ToInt32(Session["AccountId"]);
                var messageList = messagebusiness.GetUserSendBoxMessages(Id);

                return Json(messageList, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                throw new NotSupportedException("Beklenmedik bir hata oluştu !", ex);
            }
        }
        
        public ActionResult ReadMessage(int Id)
        {
            try
            {
                if (Session["Account"] == null)
                {
                    return RedirectToAction("SingupAndSignin", "Account");
                }
                else
                {
                    var messagebusiness = new MessageBusiness();
                    var message = messagebusiness.GetByMessage(Id);
                    var userbusiness = new UserBusiness();
                    var senderUser = userbusiness.GetUserInfo(message.SendUser);
                    var ReceiverUser = userbusiness.GetUserInfo(message.ReceiverUser);
                    messagebusiness.ChangeStatus(Id);
                    var ReadMessageVM = new ReadMessageViewModel()
                    {
                        Message = message,
                        SenderName = senderUser.UserName,
                        ReceiverName = ReceiverUser.UserName
                    };
                    return View(ReadMessageVM);
                }
            }
            catch
            {
                return RedirectToAction("SingupAndSignin", "Account");
            }
        }

        public ActionResult WriteMessage(int Id)
        {
            try
            {
                if (Session["Account"] == null)
                {
                    return RedirectToAction("SingupAndSignin", "Account");
                }
                else
                {
                    var user = new UserBusiness();
                    var ReceiverUserInfo = user.GetUserInfo(Id);
                    var SenderUserInfo = user.GetUserInfo((int)Session["AccountId"]);
                    var WriteMessageWM = new WriteMessageViewModel()
                    {
                        SenderName = SenderUserInfo,
                        ReceiverName = ReceiverUserInfo,
                    };

                    return View(WriteMessageWM);
                }
            }
            catch
            {
                return RedirectToAction("SingupAndSignin", "Account");
            }


        }

        public JsonResult SendMessage(Message message)
        {
            try
            {
                var messagebusiness = new MessageBusiness();

                messagebusiness.SendMessage(message);
                return Json(message, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                throw new NotSupportedException("Beklenmedik bir hata oluştu !", ex);
            }
        }

        public ActionResult ReplyMessage(int Id)
        {
            var messagebusiness = new MessageBusiness();
            var message = messagebusiness.GetByMessage(Id);
            var userbusiness = new UserBusiness();
            var sendUser = userbusiness.GetUserInfo(message.SendUser);
            var ReadMessageVM = new ReadMessageViewModel()
            {
                SenderName = sendUser.UserName,
                Message = message
            };
            return View(ReadMessageVM);
        }
    }
}