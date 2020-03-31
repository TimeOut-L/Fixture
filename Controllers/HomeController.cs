using FixtureManagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FixtureManagement.Controllers
{
    public class HomeController:Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public JsonResult GetUserName()
        {
            User currentUser = (User)Session["CurrentUser"];
            var data = new
            {
                //result = true,
                userName = currentUser.Name
            };
            return Json(data, JsonRequestBehavior.AllowGet);
        }
    }
}