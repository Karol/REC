using System;
using System.Collections.Generic;

namespace Mvckarolnew.Models
{
    public class TypeToType
    {
        public int Id { get; set; }
        public int IdParent { get; set; }
        public int IdSub { get; set; }
        public virtual Type Type { get; set; }
        public virtual Type Type1 { get; set; }
    }
}
