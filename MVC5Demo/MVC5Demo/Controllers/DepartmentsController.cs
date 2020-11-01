using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Http.Results;
using System.Web.Mvc;
using MVC5Demo.Models;
using Omu.ValueInjecter;

namespace MVC5Demo.Controllers
{
    public class DepartmentsController : BaseController
    {
        DepartmentRepository repo;
        PersonRepository repoPerson;
        CourseRepository repoCourse;
        public DepartmentsController()
        {
            repo = RepositoryHelper.GetDepartmentRepository();
            repoPerson = RepositoryHelper.GetPersonRepository(repo.UnitOfWork);
            repoCourse = RepositoryHelper.GetCourseRepository(repo.UnitOfWork);
        }
        // GET: Departments
        public ActionResult Index()
        {
            return View(repo.All());//.ToList() 直接db.Department本身是dbSet 第一次查詢才會
        }//存取資料庫資料

        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var dept = repo.GetOne(id.Value);

            if (dept == null)
            {
                return HttpNotFound();
            }

            return View(dept);
        }

        public ActionResult Create()
        {
            ViewBag.InstructorID = new SelectList(repoPerson.All(), "ID", "FirstName");
            return View();
        }

        [HttpPost]
        public ActionResult Create(DepartmentEdit department)//目前View上沒RowVersion 但萬一有人傳多的欄位，可試圖調整 這種攻擊叫OverPosting
        {//另個解決方法 設計出給View用的Model 叫ViewModel 間接
            if (ModelState.IsValid)
            {
                var item = new Department();
                item.InjectFrom(department);
                repo.Add(item);
                repo.UnitOfWork.Commit();

                return RedirectToAction("Index");
            }

            ViewBag.InstructorID = new SelectList(repoPerson.All().OrderBy(p => p.FirstName), "ID", "FirstName");

            return View(department);
        }

        public ActionResult Edit(int? id)
        {
            if (!id.HasValue)
            {
                return HttpNotFound();
            }

            var dept = repo.GetOne(id.Value);

            ViewBag.InstructorID = new SelectList(repoPerson.All().OrderBy(p => p.FirstName), "ID", "FirstName", dept.InstructorID);

            return View(dept);
        }

        [HttpPost]
        public ActionResult Edit(int id, DepartmentEdit department)
        {
            if (ModelState.IsValid)
            {
                var item = repo.GetOne(id);

                item.InjectFrom(department);

                repo.UnitOfWork.Commit();

                return RedirectToAction("Index");
            }

            var dept = repo.GetOne(id);

            ViewBag.InstructorID = new SelectList(repoPerson.All(), "ID", "FirstName", dept.InstructorID);

            return View(dept);
        }

        [ChildActionOnly]
        public ActionResult CoursesUnderDetails(int id)
        {
            var data = repoCourse.All().Where(p => p.DepartmentID == id);
            return PartialView(data);
        }

        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var dept = repo.GetOne(id.Value);

            if (dept == null)
            {
                return HttpNotFound();
            }

            return View(dept);
        }

        // POST: Departments/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            var dept = repo.GetOne(id);
            repo.Delete(dept);
            repo.UnitOfWork.Commit();

            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                //db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}