using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC5Demo.Controllers
{
    public abstract class BaseController : Controller
    {
        protected override void HandleUnknownAction(string actionName)
        {
            //base.HandleUnknownAction(actionName);// 元預設動作
            this.Redirect("/?redir=" + actionName).ExecuteResult(ControllerContext);//轉到首頁，並提示從哪轉
        }
    }
}