using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Mvckarolnew.Models;
using Type = Mvckarolnew.Models.Type;
using ViewType = Mvckarolnew.Models.ViewType;

namespace Mvckarolnew.Controllers
{ 
    public class TypeController : Controller
    {
        private MvcContext db = new MvcContext();
        private MyConvert swap = new MyConvert();
        private Validation myval = new Validation();
        
        // GET: /Type/

        public ViewResult Index()
        {
            var model = new ViewType();
            model.TypeV = db.Types;

            return View(model);
        }

        // GET: /Type/Details/5

        public ViewResult Details(int id)
        {
            Type type = db.Types.Find(id);

            return View(swap.ToViewType(type));
        }

        // GET: /Type/Create

        public ActionResult Create()
        {
            return View();
        } 

        // POST: /Type/Create

        [HttpPost]
        public ActionResult Create(ViewType typeV)
        {
            if (ModelState.IsValid)
            {

                if (myval.ValType(typeV))
                {
                   TempData["validation"] = "istnieje";
                   
                    return RedirectToAction("Create");
                }
                else
                {
                    db.Types.Add(swap.ToType(typeV));
                    db.SaveChanges();
                }
                return RedirectToAction("Index");  
            }

            return View(typeV);
        }
        
        // GET: /Type/Edit/5
 
        public ActionResult Edit(int id)
        {
            Type type = db.Types.Find(id);

            return View(swap.ToViewType(type));
        }

        // POST: /Type/Edit/5

        [HttpPost]
        public ActionResult Edit(ViewType typeV)
        {
            if (ModelState.IsValid)
            {
                if (myval.ValType(typeV))
                {
                    TempData["validation"] = "istnieje";

                    return RedirectToAction("Edit");
                }
                else
                {
                    Type typeOrg = db.Types.First(p=>p.Id == typeV.IdV);
                    typeOrg.Name = typeV.NameV;

                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
            }
            return View(typeV);
        }

        // GET: /Type/Delete/5
 
        public ActionResult Delete(int id)
        {
            Type type = db.Types.Find(id);

            return View(swap.ToViewType(type));
        }

        // POST: /Type/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {            
            Type type = db.Types.Find(id);
           
            foreach (var item in db.TypeToTypes.Where(p=>p.IdSub == type.Id))
            {
                    db.TypeToTypes.Remove(item);                
            }

            db.Types.Remove(type);
            db.SaveChanges();

            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}