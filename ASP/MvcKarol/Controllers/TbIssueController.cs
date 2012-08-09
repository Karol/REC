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
    public class TbIssueController : Controller
    {
        private TablesContext db = new TablesContext();
        MyConvert convert = new MyConvert();

        // GET: /TbIssue/

        public ViewResult Index()
        {
            var mymodel = new IssueViewModel();
            mymodel.IssueAll = db.TbIssues.Include(p => p.TbType);

            return View(mymodel);
        }
        
        // GET: /TbIssue/Details/5

        public ViewResult Details(int id)
        {
            TbIssue tbissue = db.TbIssues.Find(id);
            return View(convert.ConvertIssueToView(tbissue));
        }
       
        // GET: /TbIssue/Create

        public ActionResult Create()
        {
            var model = new IssueViewModel();
            model.List = db.TbTypes;

            return View(model);
        } 
        
        // POST: /TbIssue/Create

        [HttpPost]
        public ActionResult Create(IssueViewModel tbissue)
        {
            if (ModelState.IsValid)
            {
                var z = db.TbTypes.First(p => p.TbTypeID == tbissue.TbtypeN.TbTypeID);
                tbissue.TbtypeN = z;

                db.TbIssues.Add(convert.ConvertIssue(tbissue));
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tbissue);
        }
        
        // GET: /TbIssue/Edit/5
 
        public ActionResult Edit(int id)
        {
            TbIssue tbissueOrg = db.TbIssues.First(p => p.TbIssueID == id);
            var model = new IssueViewModel();
            model = convert.ConvertIssueToView(tbissueOrg);
            model.List = db.TbTypes;
            
            return View(model);
        }
        
        // POST: /TbIssue/Edit/5

        [HttpPost]
        public ActionResult Edit(IssueViewModel tbissue)
        {
            TbIssue tbissueOrg;
            //var issue = convert.ConvertIssue(tbissue);
            if (ModelState.IsValid)
            {
                tbissueOrg = db.TbIssues.First(p => p.TbIssueID == tbissue.IssueId);
                tbissueOrg.Name = tbissue.IssueName;
                tbissueOrg.Text = tbissue.IssueText;
                tbissueOrg.TbType = db.TbTypes.First(p=>p.TbTypeID == tbissue.TbtypeN.TbTypeID);

                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tbissue);
        }
    
        // GET: /TbIssue/Delete/5
 
        public ActionResult Delete(int id)
        {
            TbIssue tbissue = db.TbIssues.Find(id);
            return View(convert.ConvertIssueToView(tbissue));
        }

        // POST: /TbIssue/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {            
            TbIssue tbissue = db.TbIssues.Find(id);
            db.TbIssues.Remove(tbissue);
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