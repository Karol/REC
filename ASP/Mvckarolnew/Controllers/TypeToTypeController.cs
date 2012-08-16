using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Mvckarolnew.Models;

namespace Mvckarolnew.Controllers
{ 
    public class TypeToTypeController : Controller
    {
        private MvcContext db = new MvcContext();
        private MyConvert swap = new MyConvert();
        private Validation val = new Validation();

        // GET: /TypeToType/

        public ViewResult Index()
        {
            ViewTypeToType model = new ViewTypeToType();
            model.ListTypeToType = db.TypeToTypes.ToList();

            #region DeleteRepead

            List<int> NoR = new List<int>();
            foreach (var item in model.ListTypeToType)
            {
                NoR.Add(item.IdParent);
            }
            model.NoRepeadParent = NoR.Distinct();

            #endregion

            return View(model);
        }

        // GET: /TypeToType/Details/5

        public ViewResult Details(int id)
        {
            TypeToType typetotype = db.TypeToTypes.Find(id);

            return View(swap.ToViewTypeToType(typetotype));
        }
        
        // GET: /TypeToType/Create

        public ActionResult Create()
        {
            ViewBag.IdParentV = new SelectList(db.Types, "Id", "Name");
            ViewBag.IdSubV = new SelectList(db.Types, "Id", "Name");
            return View();
        } 
        
        // POST: /TypeToType/Create

        [HttpPost]
        public ActionResult Create(ViewTypeToType typetotypeV)
        {
            if (ModelState.IsValid)
            {
                if (val.ValTypeToType(typetotypeV))
                {
                    TempData["validation"] = "istnieje";

                    return RedirectToAction("Create");
                }
                else
                {
                    db.TypeToTypes.Add(swap.ToTypeToType(typetotypeV));
                    db.SaveChanges();
                }
                return RedirectToAction("Index");  
            }

            ViewBag.IdParentV = new SelectList(db.Types, "Id", "Name", typetotypeV.IdParentV);
            ViewBag.IdSubV = new SelectList(db.Types, "Id", "Name", typetotypeV.IdSubV);
            return View(typetotypeV);
        }

        // GET: /TypeToType/Edit/5
 
        public ActionResult Edit(int id)
        {
            TypeToType typetotype = db.TypeToTypes.Find(id);
            ViewTypeToType typetotypeV = swap.ToViewTypeToType(typetotype);

            ViewBag.IdParentV = new SelectList(db.Types, "Id", "Name", typetotypeV.IdParentV);
            ViewBag.IdSubV = new SelectList(db.Types, "Id", "Name", typetotypeV.IdSubV);
            
            return View(typetotypeV);
        }

        // POST: /TypeToType/Edit/5

        [HttpPost]
        public ActionResult Edit(ViewTypeToType typetotypeV)
        {
            if (ModelState.IsValid)
            {
                if (val.ValTypeToType(typetotypeV))
                {
                    TempData["validation"] = "istnieje";

                    return RedirectToAction("Edit");
                }
                else
                {
                    TypeToType typetotypeOrg = db.TypeToTypes.First(p => p.Id == typetotypeV.IdV);
                    typetotypeOrg.IdParent = typetotypeV.IdParentV;
                    typetotypeOrg.IdSub = typetotypeV.IdSubV;
                    typetotypeOrg.Type = typetotypeV.ParentTypeV;
                    typetotypeOrg.Type1 = typetotypeV.SubTypeV;

                    db.SaveChanges();

                    return RedirectToAction("Index");
                }
            }
            ViewBag.IdParentV = new SelectList(db.Types, "Id", "Name", typetotypeV.IdParentV);
            ViewBag.IdSubV = new SelectList(db.Types, "Id", "Name", typetotypeV.IdSubV);
            return View(typetotypeV);
        }

        // GET: /TypeToType/Delete/5
 
        public ActionResult Delete(int id)
        {
            TypeToType typetotype = db.TypeToTypes.Find(id);

            return View(swap.ToViewTypeToType(typetotype));
        }

        // POST: /TypeToType/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {            
            TypeToType typetotype = db.TypeToTypes.Find(id);

            db.TypeToTypes.Remove(typetotype);
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