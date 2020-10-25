using MVC5Demo.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC5Demo.Controllers
{
    public class ReportsController : Controller
    {
        ContosoUniversityEntities db = new ContosoUniversityEntities();

        public ReportsController()//ctor tab => 建構式
        {
            db.Database.Log = (msg) =>
            {
                Debug.WriteLine("-----------------------------------");
                Debug.WriteLine(msg);//好debug 方法
                Debug.WriteLine("-----------------------------------"); ;
            };
        }
        // GET: Reports
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult CoursesReport1()//多對多
        {
            var data = from c in db.Course
                       select new CoursesReport1VM
                       {
                           CourseID = c.CourseID,
                           CourseName = c.Title,
                           StudentCount = c.Enrollments.Count,//導覽屬性看出關聯
                           TeacherCount = c.Teachers.Count,
                           AvgGrade = c.Enrollments.Where(e => e.Grade.HasValue).Average(p => p.Grade.Value)//DB設計有問題時，如允許空直 不能Average().Value 另個問題是有沒隊到Enrollments的狀況

                       };
            //第一種
            return View(data);//不好 一堆subquery
        }

        public ActionResult CoursesReport2()//
        {
            var data = db.Database.SqlQuery<CoursesReport1VM>(@"SELECT          Course.CourseID, Course.Title AS CourseName, COUNT(Enrollment.EnrollmentID) AS Enrollments,  COUNT( CourseInstructor.InstructorID) AS TeacherCount, AVG(CAST(Enrollment.Grade AS float)) AS AvgGrade
FROM dbo.Course 
LEFT JOIN dbo.CourseInstructor ON dbo.Course.CourseID = dbo.CourseInstructor.CourseID 
LEFT JOIN dbo.Enrollment ON dbo.Course.CourseID = dbo.Enrollment.CourseID
GROUP BY dbo.Course.CourseID, Course.Title");//只要能對應 就能產出
            //第二種
            return View("CoursesReport1",data);//第二種 View("CoursesReport1", 可使用指定View, SQL Query Designer
        }

        public ActionResult CoursesReport3(int id)//一筆
        {
            var data = db.Database.SqlQuery<CoursesReport1VM>(@"SELECT          Course.CourseID, Course.Title AS CourseName, COUNT(Enrollment.EnrollmentID) AS Enrollments,  COUNT( CourseInstructor.InstructorID) AS TeacherCount, AVG(CAST(Enrollment.Grade AS float)) AS AvgGrade
FROM dbo.Course 
LEFT JOIN dbo.CourseInstructor ON dbo.Course.CourseID = dbo.CourseInstructor.CourseID 
LEFT JOIN dbo.Enrollment ON dbo.Course.CourseID = dbo.Enrollment.CourseID
WHERE Course.CourseID = @p0
GROUP BY dbo.Course.CourseID, Course.Title", id);//一定要參數化，不能組字串 ，自動帶的從p0開始
            //第二種
            return View("CoursesReport1", data);//第二種 View("CoursesReport1", 可使用指定View, SQL Query Designer
        }
    }
}