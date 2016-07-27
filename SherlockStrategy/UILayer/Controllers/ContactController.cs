using BusinessLayer.Business;
using Models.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace UILayer.Controllers
{
    public class ContactController : Controller
    {
        public ActionResult ContactForm()
        {
            return View();
        }

        public JsonResult SendContactMessage(Contact contact)
        {
            try
            {
                var contactBusiness = new ContactBusiness();
                contactBusiness.SendContactMessage(contact);
                var returnMessage = "Mesajınız Başarılı Bir Şekilde İletildi !";
                return Json(returnMessage, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(ex, "Beklenmedik Bir Hata İle Karşılaşıldı !");
            }
        }

        public ActionResult ContactFormMessage()
        {
            return View();
        }

        public JsonResult GetContactFormMessage()
        {
            try
            {
                var contactBusiness = new ContactBusiness();
                var messageList = contactBusiness.GetContactFormMessage();
                return Json(messageList, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(ex);
            }
        }
    }
}