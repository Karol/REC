using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Mvckarolnew.Models
{
    public class Validation
    {
        MvcContext db = new MvcContext();

        public bool ValType(ViewType typeV)
        {
            bool exist = false;

            foreach(var item in db.Types)
            {
                if (typeV.NameV.ToLower() == item.Name.ToLower())
                {
                    exist = true;
                }
            }            
                return exist;
        }

        public bool ValTypeToType(ViewTypeToType typetotypeV)
        {
            bool exist = false;

            foreach (var item in db.TypeToTypes)
            {
                if (typetotypeV.IdParentV == item.IdParent && typetotypeV.IdSubV == item.IdSub)
                {
                    exist = true;
                }
            }
            return exist;
        }
    }
}