using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MvcKarol.Models
{
    public class TbType
    {
        public int TbTypeID { get; set; }
        public string Name { get; set; }

        public virtual ICollection<TbIssue> TbIssue { get; set;}
        public virtual ICollection<TbType> TbbType { get; set; }
    }
}