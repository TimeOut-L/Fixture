using FixtureManagement.filter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FixtureManagement.Controllers
{
    [LoginCheckFilter]
    //归还
    public class InRecordController : Controller
    {
        // GET: InRecord
        public ActionResult Index()
        {
            return View();
        }
    }
}