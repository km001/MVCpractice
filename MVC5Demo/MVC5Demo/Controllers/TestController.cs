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
        public ActionResult Create(Person person)
        {
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
        public ActionResult Edit(int id,Person person)
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
    }
}