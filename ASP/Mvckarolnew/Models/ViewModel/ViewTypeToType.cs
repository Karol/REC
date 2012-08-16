using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Mvckarolnew.Models
{
    public class ViewTypeToType
    {
        public int IdV { get; set; }
        public int IdParentV { get; set; }
        public int IdSubV { get; set; }
        public Type ParentTypeV { get; set; }
        public Type SubTypeV { get; set; }

        public IEnumerable<TypeToType> ListTypeToType { get; set; }
        public IEnumerable<int> NoRepeadParent { get; set; } 
    }
}