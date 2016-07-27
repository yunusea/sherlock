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
                var messageBusiness = new MessageBusiness();

                var Id = Convert.ToInt32(Session["AccountId"]);
                var messageList = messageBusiness.GetUserInBoxMessages(Id);

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
                var messageBusiness = new MessageBusiness();


                messageBusiness.DeleteMessage(Entity);

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
                var messageBusiness = new MessageBusiness();

                var Id = Convert.ToInt32(Session["AccountId"]);
                var messageList = messageBusiness.GetUserSendBoxMessages(Id);

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
                    var messageBusiness = new MessageBusiness();
                    var message = messageBusiness.GetByMessage(Id);
                    var userBusiness = new UserBusiness();
                    var senderUser = userBusiness.GetUserInfo(message.SendUser);
                    var ReceiverUser = userBusiness.GetUserInfo(message.ReceiverUser);
                    messageBusiness.ChangeStatus(Id);
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
                    var userBusiness = new UserBusiness();
                    var ReceiverUserInfo = userBusiness.GetUserInfo(Id);
                    var SenderUserInfo = userBusiness.GetUserInfo((int)Session["AccountId"]);
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
                var messageBusiness = new MessageBusiness();

                messageBusiness.SendMessage(message);
                return Json(message, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                throw new NotSupportedException("Beklenmedik bir hata oluştu !", ex);
            }
        }

        public ActionResult ReplyMessage(int Id)
        {
            var messageBusiness = new MessageBusiness();
            var message = messageBusiness.GetByMessage(Id);
            var userBusiness = new UserBusiness();
            var sendUser = userBusiness.GetUserInfo(message.SendUser);
            var ReadMessageVM = new ReadMessageViewModel()
            {
                SenderName = sendUser.UserName,
                Message = message
            };
            return View(ReadMessageVM);
        }

        public JsonResult ReplyMessageSave(ReplySendViewMode ReplySendVM)
        {
            try
            {
                var replyObject = ReplySendVM;
                var messageBusiness = new MessageBusiness();
                var message = messageBusiness.GetByMessage(replyObject.messageId);
                var AccountId = Convert.ToInt32(Session["AccountId"]);
                var replyMessageObject = new Message()
                {
                    Date = DateTime.Now,
                    MessageText = replyObject.ReplyContent,
                    ReceiverUser = message.SendUser,
                    Status = false,
                    SendUser = AccountId,
                    Subject = message.Subject
                };

                messageBusiness.SendMessage(replyMessageObject);

                var viewMessage = "Mesajınız Başarılı Bir Şekilde Gönderilmiştir !";
                return Json(viewMessage, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                throw new NotSupportedException("Beklenmedik bir hata oluştu !", ex);
            }
        }
    }
}