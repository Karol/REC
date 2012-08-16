using System;
using System.Collections.Generic;

namespace Mvckarolnew.Models
{
    public class Issue
    {
        public int Id { get; set; }
        public Nullable<int> IdType { get; set; }

        public string Name { get; set; }
        public string Text { get; set; }
        public virtual Type Type { get; set; }
    }
}
