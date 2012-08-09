using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcKarol.Models
{
    public class TypViewModel
    {
        public IList<TbType> TypAll { get; set; }
        public int TypID { get; set; }
        public string TypName { get; set; }
    }
}