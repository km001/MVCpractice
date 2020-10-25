using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC5Demo.Controllers
{
    public class HomeController : BaseController
    {
        protected override void HandleUnknownAction(string actionName)
        {
            //base.HandleUnknownAction(actionName);// 元預設動作
            this.Redirect("/?redir=" + actionName).ExecuteResult(ControllerContext);//轉到首頁，並提示從哪轉
        }
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
    }
}