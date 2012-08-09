﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcKarol.Models;

namespace MvcKarol.Controllers
{
    public class HomeController : Controller
    {
        private TablesContext db = new TablesContext();

        public ActionResult Index()
        {
            ViewBag.Message = "Welcome to ASP.NET MVC!";
            return View();
        }

        public ActionResult Index1()
        {
            return View();
        }

        public ActionResult MyView()
        {
            return View(db.TbTypes.ToList());
        }
        public ActionResult About()
        {
            return View();
        }
    }
}