using FixtureManagement.filter;
using FixtureManagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FixtureManagement.Controllers
{
    [LoginCheckFilter]
    public class HomeController:Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult test()
        {
            return View();
        }

        [HttpGet]
        public ActionResult GetUserName()
        {
            User currentUser = (User)Session["CurrentUser"];
            var data = new List<Object>();
            data.Add(new
            {
                //result = true,
                userName = currentUser.Name
            });
            return Json(data, JsonRequestBehavior.AllowGet);
        }
    }
}