using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Mvckarolnew.Models;

namespace Mvckarolnew.Controllers
{
    public class HomeController : Controller
    {
        MvcContext db = new MvcContext();

        public ActionResult Index()
        {
            db.Database.CreateIfNotExists();

            ViewBag.Message = "Welcome to ASP.NET MVC!";

            return View();
        }

        public ActionResult About()
        {
            return View();
        }
    }
}
