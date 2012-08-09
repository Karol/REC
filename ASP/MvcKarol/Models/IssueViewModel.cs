using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;



namespace MvcKarol.Models
{
    public class IssueViewModel
    {
        public IQueryable<TbIssue> IssueAll { get; set; }
        public int IssueId { get; set; }
        public string IssueName { get; set; }
        public string IssueText { get; set; }
        public TbType TbtypeN { get; set; }
        public IEnumerable<TbType> List {get; set;}
    }
}