using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Ajax;
using Clockwork.Web.Helpers;
using Clockwork.Web.Models;

namespace Clockwork.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly APIHelper apiConn;
        private const string strGetAllQueryURL = "http://localhost:5000/api/currenttime/getall";

        public HomeController(){
            apiConn = new APIHelper();
        }

        public ActionResult Index()
        {
            var homeModel = new HomeModel();
            homeModel.CurrentTimeQueries = apiConn.GetFromURL<List<CurrentTimeQuery>>(strGetAllQueryURL) ?? new List<CurrentTimeQuery>();

            var mvcName = typeof(Controller).Assembly.GetName();
            var isMono = Type.GetType("Mono.Runtime") != null;

            ViewData["Version"] = mvcName.Version.Major + "." + mvcName.Version.Minor;
            ViewData["Runtime"] = isMono ? "Mono" : ".NET";

            return View(model:homeModel);
        }
    }
}
