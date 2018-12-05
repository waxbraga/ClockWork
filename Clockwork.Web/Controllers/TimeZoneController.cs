using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Clockwork.Web.Models;

namespace Clockwork.Web.Controllers
{
    public class TimeZoneController : Controller
    {
        public ActionResult Index()
        {
            var tzModel = new TimeZoneModel();

            return View (tzModel);
        }
    }
}