﻿using System;
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
    public class DepartmentsController : Controller
    {
        ContosoUniversityEntities db = new ContosoUniversityEntities();
        // GET: Departments
        public ActionResult Index()
        {
            return View(db.Department);//.ToList() 直接db.Department本身是dbSet 第一次查詢才會
        }//存取資料庫資料

        public ActionResult Details(int? id)
        {
            if (!id.HasValue)
            {
                return HttpNotFound();
            }

            Department department = db.Department.Find(id);
            if (department == null)
            {
                return HttpNotFound();
            }

            return View(department);
        }

        public ActionResult Create()
        {
            ViewBag.InstructorID = new SelectList(db.Person, "ID", "FirstName");
            return View();
        }

        [HttpPost]
        public ActionResult Create(DepartmentEdit department)//目前View上沒RowVersion 但萬一有人傳多的欄位，可試圖調整 這種攻擊叫OverPosting
        {//另個解決方法 設計出給View用的Model 叫ViewModel 間接
            if (ModelState.IsValid)
            {
                Department item = new Department();
                item.InjectFrom(department);
                db.Department.Add(item);//物件寫到集合
                db.SaveChanges();

                return RedirectToAction("Index");
            }
            ViewBag.InstructorID = new SelectList(db.Person, "ID", "FirstName");

            return View();
        }

        public ActionResult Edit(int? ID)
        {
            if (!ID.HasValue)
            {
                return HttpNotFound();
            }
            var item = db.Department.Find( ID.Value);

            ViewBag.InstructorID = new SelectList(db.Person, "ID", "FirstName", item.InstructorID);

            return View(item);
        }

        [HttpPost]
        public ActionResult Edit(int ID, DepartmentEdit department)
        {
            if (ModelState.IsValid)
            {
                var item = db.Department.Find(ID);//有變更追蹤的機制

                item.InjectFrom(department);//名子一樣copy過去

                //item.Name = department.Name;
                //item.Budget = department.Budget;
                //item.StartDate = department.StartDate;
                //item.InstructorID = department.InstructorID;//所以直接對物件操作就OK
                //一個個只把要更新的打進去，比較不怕OverPosting，高可讀性(解釋意圖intension) 代價是多欄位時比較麻煩

                db.SaveChanges();

                return RedirectToAction("Index");
            }

            var dept = db.Department.Find(ID);

            ViewBag.InstructorID = new SelectList(db.Person, "ID", "FirstName", dept.InstructorID);

            return View(dept);
        }

        public ActionResult Delete(int? id)
        {
            if (!id.HasValue)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Department department = db.Department.Find(id);
            if (department == null)
            {
                return HttpNotFound();
            }
            return View(department);
        }

        // POST: Departments/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Department department = db.Department.Find(id);
            db.Department.Remove(department);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}