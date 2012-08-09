using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MvcKarol.Models
{

    public class TbIssue
    {
        public int TbIssueID { get; set; }
        public string Name { get; set; }
        public string Text { get; set; }

        public virtual TbType TbType { get; set; }
    }
}