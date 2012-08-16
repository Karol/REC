using System;
using System.Collections.Generic;

namespace Mvckarolnew.Models
{
    public class Type
    {
        public Type()
        {
            this.Issues = new List<Issue>();
            this.TypeToTypes = new List<TypeToType>();
            this.TypeToTypes1 = new List<TypeToType>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public virtual ICollection<Issue> Issues { get; set; }
        public virtual ICollection<TypeToType> TypeToTypes { get; set; }
        public virtual ICollection<TypeToType> TypeToTypes1 { get; set; }
    }
}
