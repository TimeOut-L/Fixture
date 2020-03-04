using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FixtureManagement.Controllers
{
    public class LoginController :Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult DoLogin(String code ,String password)
        {
            
            return RedirectToAction("Index","Home");
        }
    }
}