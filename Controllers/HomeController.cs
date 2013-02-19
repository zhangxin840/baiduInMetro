using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BaiduInMetro.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {

            return Redirect("~/BaiduInMetro/getContent.html");
        }
        public string TestAction()
        {
            return "Test Action";
            //return Redirect("~/BaiduInMetro/getContent.html");
        }
    }
}
