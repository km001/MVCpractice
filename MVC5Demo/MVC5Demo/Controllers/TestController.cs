using MVC5Demo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC5Demo.Controllers
{
    public class TestController : Controller
    {
        static List<Person> data = new List<Person>()
            {
                new Person() { Id = 1, Name = "Will", Age = 18 },
                new Person() { Id = 2, Name = "Maa", Age = 19 },
                new Person() { Id = 3, Name = "Ace", Age = 20 },
                new Person() { Id = 4, Name = "Ite", Age = 21 }
            };
        // GET: Test
        public ActionResult Index()
        {

            return View(data);
        }

        [HttpGet]
        public ActionResult Create()
        {

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Person person)
        {
            person.Id = data.OrderByDescending(u => u.Id).Select(u => u.Id).FirstOrDefault() + 1;//取Id
            if (ModelState.IsValid)
            {
                data.Add(person);
                return RedirectToAction("Index");
            }

            return View(data);
        }

        [HttpGet]//<==Get是預設
        public ActionResult Edit(int id)
        {
            return View(data.FirstOrDefault(p=>p.Id==id));
        }

        [HttpPost]
        public ActionResult Edit(int id,Person person)//這裡的id來自url route 只要跟routeconfig的參數名稱依樣就會接到
        {
            if (ModelState.IsValid)
            {
                var one = data.FirstOrDefault(p => p.Id == id);
                one.Name = person.Name;
                one.Age = person.Age;
                return RedirectToAction("Index");
            }

            return View(data);
        }

        [HttpGet]//<==Get是預設
        public ActionResult Details(int id)
        {
            return View(data.FirstOrDefault(p => p.Id == id));
        }

        [HttpGet]//<==Get是預設
        public ActionResult Delete(int id)//確認用
        {
            return View(data.FirstOrDefault(p => p.Id == id));
        }

        [HttpPost]
        public ActionResult Delete(int id, FormCollection form)//方法名稱與參數依樣，不建議再塞無用變數(FormCollection)
        {
            data.Remove(data.FirstOrDefault(p => p.Id == id));
            return RedirectToAction("Index");
        }
    }
}