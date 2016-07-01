using BusinessLayer;
using BusinessLayer.Business;
using DataLayer.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace UILayer.Controllers
{
    public class AccountController : Controller
    {
        // GET: Account
        public ActionResult SingUp()
        {
            return View();
        }

        public ActionResult SaveUser(User Entity)
        {
            try
            {
                var user = new UserBusiness();

                user.AddUser(Entity);

                return RedirectToAction("SingUp", "Account");
            }
            catch (Exception ex)
            {
                return Json(ex.Message);
            }
        }
    }
}