using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC5Demo.Controllers
{
    public class HomeController : BaseController
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult Test()
        {
            //ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult RazorPractice01()
        {
            var data = new int[] { 1, 2, 3, 4, 5 };
            ViewBag.data = data;
            return PartialView();
        }

#if !DEBUG
        [NonAction]
#endif
        [LocalOnly]
        public ActionResult Debug()
        {
            return Content("DEBUG");
        }
    }
}