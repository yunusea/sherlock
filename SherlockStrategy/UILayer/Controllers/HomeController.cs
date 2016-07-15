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