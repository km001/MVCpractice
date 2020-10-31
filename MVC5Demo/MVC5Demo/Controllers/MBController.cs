using MVC5Demo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Omu.ValueInjecter;

namespace MVC5Demo.Controllers
{
    public class MBController : Controller
    {
        CourseRepository repoCourse;
        DepartmentRepository repo;
        public MBController()
        {
            repoCourse = RepositoryHelper.GetCourseRepository();
            repo = RepositoryHelper.GetDepartmentRepository();
        }
        // GET: MB
        public ActionResult Index(int id = 1)
        {
            if (id > 3)
            {
                var data = repo.GetOne(id);
                ViewData.Model = data;
            }
            else
            {
                var data = repo.GetOne(1);
                ViewData.Model = data;
            }

            ViewData["Key1"] = "Hello";
            ViewBag.Key2 = "World";

            TempData["Message"] = "2020/10/31";

            return View();
        }

        public ActionResult ReadTempData()
        {
            return View();
        }

        public ActionResult CourseBatchEdit(bool IsEditMode = false)
        {
            ViewData.Model = repoCourse.All();

            ViewBag.IsEditMode = IsEditMode;

            return View();
        }

        [HttpPost]
        public ActionResult CourseBatchEdit(List<CourseBatchEditVM> data, bool IsEditMode = false)
        {
            if (ModelState.IsValid)
            {
                foreach (var item in data)
                {
                    var course = repoCourse.All().FirstOrDefault(p => p.CourseID == item.CourseID);
                    course.InjectFrom(item);
                }
                repoCourse.UnitOfWork.Commit();

                TempData["CourseBatchEditResult"] = "批次更新成功！";

                return RedirectToAction("CourseBatchEdit");
            }

            ViewBag.IsEditMode = IsEditMode;

            return View(repoCourse.All());
        }
    }
}