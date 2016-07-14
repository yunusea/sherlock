using Models.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Services.Description;

namespace UILayer.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            try
            {
                if (Session["Account"] != null)
                {
                    var _user = new User();
                    var _loginUserInfo = Session["Account"];


                    return Json(_loginUserInfo, JsonRequestBehavior.AllowGet);
                }
                else
                {
                    return RedirectToAction("SingupAndSignin", "Account");
                }
            }
            catch (Exception ex)
            {
                return RedirectToAction("SingupAndSignin", "Account");
            }
           
        }
    }
}