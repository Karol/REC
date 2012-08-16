using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Mvckarolnew.Models
{
    public class ViewIssue
    {
        public int IdV { get; set; }
        public Nullable<int> IdTypeV { get; set; }
        public string NameV { get; set; }
        public string TextV { get; set; }

        public Type TypeV { get; set; }
        public IEnumerable<Type> TypeIEnumV { get; set; }
        public IEnumerable<Issue> ListViewIssue { get; set; }
    }
}