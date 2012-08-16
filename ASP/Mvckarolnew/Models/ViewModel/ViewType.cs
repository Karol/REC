using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Mvckarolnew.Models
{
    public class ViewType
    {
        public int IdV { get; set; }
        public string NameV { get; set; }

        public IEnumerable<Type> TypeV { get; set; }
        public IEnumerable<Type> ParentTypeV { get; set; }
    }
}