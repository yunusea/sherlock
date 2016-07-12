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

        public JsonResult GetUserList()
        {
            try
            {
                var user = new UserBusiness();

                var _listSites = user.GetAllUserList();

                return Json(_listSites, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(ex.Message);
            }
        }

        public ActionResult SaveUser(User Entity)
        {
            try
            {
                var user = new UserBusiness();

                Entity.Rol = 1;
                Entity.Status = false;
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