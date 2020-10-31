﻿using MVC5Demo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC5Demo.Controllers
{
    public class MBController : Controller
    {
        DepartmentRepository repo;
        public MBController()
        {
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
    }
}