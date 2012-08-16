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
    public class IssueController : Controller
    {
        private MvcContext db = new MvcContext();
        private MyConvert swap = new MyConvert();
        private Validation val = new Validation();

        // GET: /Issue/

        public ViewResult Index()
        {
            ViewIssue model = new ViewIssue();
            model.ListViewIssue = db.Issues.ToList();

            return View(model);
        }

        // GET: /Issue/Details/5

        public ViewResult Details(int id)
        {
            Issue issue = db.Issues.Find(id);
            return View(swap.ToViewIssue(issue));
        }

        // GET: /Issue/Create

        public ActionResult Create()
        {
            ViewBag.IdTypeV = new SelectList(db.Types, "Id", "Name");
            return View();
        } 

        // POST: /Issue/Create

        [HttpPost]
        public ActionResult Create(ViewIssue issueV)
        {
            if (ModelState.IsValid)
            {
                db.Issues.Add(swap.ToIssue(issueV));
                db.SaveChanges();
                return RedirectToAction("Index");  
            }

            ViewBag.IdTypeV = new SelectList(db.Types, "Id", "Name", issueV.IdTypeV);

            return View(issueV);
        }
        
        // GET: /Issue/Edit/5
 
        public ActionResult Edit(int id)
        {
            Issue issue = db.Issues.Find(id);
            ViewIssue issueV = swap.ToViewIssue(issue);

            ViewBag.IdTypeV = new SelectList(db.Types, "Id", "Name");

            return View(issueV);
        }

        // POST: /Issue/Edit/5

        [HttpPost]
        public ActionResult Edit(ViewIssue issueV)
        {
            if (ModelState.IsValid)
            {
                Issue issueOrg = db.Issues.First(p => p.Id == issueV.IdV);
                issueOrg.Name = issueV.NameV;
                issueOrg.Text = issueV.TextV;
                issueOrg.Type = issueV.TypeV;
                issueOrg.IdType = issueV.IdTypeV;

                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.IdTypeV = new SelectList(db.Types, "Id", "Name", issueV.IdTypeV);
            return View(issueV);
        }

        // GET: /Issue/Delete/5
 
        public ActionResult Delete(int id)
        {
            Issue issue = db.Issues.Find(id);
            return View(swap.ToViewIssue(issue));
        }

        // POST: /Issue/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {            
            Issue issue = db.Issues.Find(id);
            db.Issues.Remove(issue);
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