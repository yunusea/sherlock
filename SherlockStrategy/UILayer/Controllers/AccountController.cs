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

        public JsonResult SaveUsers(List<User> Users)
        {
            //try
            //{
            //    using (webApiDataContext dbContext = new webApiDataContext())
            //    {
            //        dbContext.Sites.AddRange(_sites);
            //        dbContext.SaveChanges();
            //    }
            //    return GetSites();
            //}
            //catch (Exception ex)
            //{
            //    return Json(ex.Message);
            //}
            return null;
        }
    }
}