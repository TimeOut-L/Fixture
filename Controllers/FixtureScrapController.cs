using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FixtureManagement.Controllers
{
    public class FixtureScrapController : Controller
    {
        // GET: FixtureScrap/Apply
        public ActionResult Apply()
        {
            return View();
        }

        // GET: FixtureScrap/FirstPass
        public ActionResult FirstPass()
        {
            return View();
        }

        // GET: FixtureScrap/LastPass 
        public ActionResult LastPass()
        {
            return View();
        }
    }
}