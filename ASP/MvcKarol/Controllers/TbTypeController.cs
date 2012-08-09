using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcKarol.Models;

namespace MvcKarol.Controllers
{ 
    public class TbTypeController : Controller
    {
        private TablesContext db = new TablesContext();
        MyConvert convert = new MyConvert();

        //
        // GET: /TbType/

        public ViewResult Index1()
        {
            var mymodel = new TypViewModel();
            mymodel.TypAll = db.TbTypes.ToList();

            return View(mymodel);
        }

        //
        // GET: /TbType/Details/5

        public ViewResult Details(int id)
        {
            TbType tbtype = db.TbTypes.Find(id);
            return View(convert.ConvertTypToView(tbtype));
        }

        //
        // GET: /TbType/Create

        public ActionResult Create()
        {
            return View();
        } 

        //
        // POST: /TbType/Create

        [HttpPost]
        public ActionResult Create(TypViewModel tbtype)
        {
            var typ = convert.ConvertTyp(tbtype);

            if (ModelState.IsValid)
            {
                db.TbTypes.Add(typ);
                db.SaveChanges();
                return RedirectToAction("Index1");  
            }

            return View(typ);
        }
        
        //
        // GET: /TbType/Edit/5
 
        public ActionResult Edit(int id)
        {
            TbType tbtype = db.TbTypes.Find(id);

            return View(convert.ConvertTypToView(tbtype));
        }

        //
        // POST: /TbType/Edit/5

        [HttpPost]
        public ActionResult Edit(TypViewModel tbtype)
        {
            if (ModelState.IsValid)
            {
                TbType tbtypeOrg = db.TbTypes.First(p => p.TbTypeID == tbtype.TypID);
                tbtypeOrg.Name = tbtype.TypName;

                db.SaveChanges();
                return RedirectToAction("Index1");
            }
            return View(tbtype);
        }

        //
        // GET: /TbType/Delete/5

        public ActionResult Delete(int id)
        {
            TbType tbtype = db.TbTypes.Find(id);
            return View(convert.ConvertTypToView(tbtype));
        }

        //
        // POST: /TbType/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {            
            TbType tbtype = db.TbTypes.Find(id);

            db.TbTypes.Remove(tbtype);

            db.SaveChanges();
            return RedirectToAction("Index1");
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}