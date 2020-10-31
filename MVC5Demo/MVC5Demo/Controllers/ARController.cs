using MVC5Demo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace MVC5Demo.Controllers
{
    public class ARController : BaseController
    {
        DepartmentRepository repo;
        // GET: AR
        public ARController()
        {
            repo = RepositoryHelper.GetDepartmentRepository();
        }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult ViewTest2()
        {
            return View("Index");
        }

        public ActionResult ViewTest3()
        {
            return View("TEMP");
        }

        public ActionResult ViewTest4()
        {
            return PartialView("Index");//PartialView沒有_layout
        }

        public ActionResult ContentTest()
        {
            return Content("<root>123</root>", "text/xml", Encoding.GetEncoding("big5"));
        }

        public ActionResult FileTest(bool dl = false)//可接GET或POST
        {
            if (dl)
            {
                return File(Server.MapPath("~/Content/bc3b2d8271f43924543571fed081b54e.png"), "image/png", "MyAA.png");//下載，與新黨名
            }
            else
            {
                return File(Server.MapPath("~/Content/bc3b2d8271f43924543571fed081b54e.png"), "image/png");//只是打開
            }
        }

        public ActionResult JsonTest()
        {
            repo.UnitOfWork.Context.Configuration.LazyLoadingEnabled = false;
            var data = repo.GetOne(1);
            return Json(data,JsonRequestBehavior.AllowGet);//得下AllowGet才能接get要求
        }

        [HttpPost]//action filter <= 讓action只能吃HttpPost
        public ActionResult JsonTest2()
        {
            var data = repo.GetOne(1);
            return Json(data);//Json 沒AllowGet，還是可以post等get以外的，
        }
    }
}