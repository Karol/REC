using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Mvckarolnew.Models
{
    public class MyConvert
    {
        public ViewType ToViewType (Type type)
        {
            return new ViewType()
            {
                IdV = type.Id,
                NameV = type.Name,                
            };
        }

        public Type ToType(ViewType typeV)
        {
            return new Type()
            {
                Id = typeV.IdV,
                Name = typeV.NameV
            };
        }

        public ViewTypeToType ToViewTypeToType(TypeToType typetotype)
        {
            return new ViewTypeToType() 
            {
                IdV = typetotype.Id,
                IdParentV = typetotype.IdParent,
                IdSubV = typetotype.IdSub,
                ParentTypeV = typetotype.Type,
                SubTypeV = typetotype.Type1
            };
        }

        public TypeToType ToTypeToType(ViewTypeToType typetotypeV)
        {
            return new TypeToType() 
            {
                Id = typetotypeV.IdV,
                IdParent = typetotypeV.IdParentV,
                IdSub = typetotypeV.IdSubV,
                Type = typetotypeV.ParentTypeV,
                Type1 = typetotypeV.SubTypeV
            };
        }

        public ViewIssue ToViewIssue(Issue issue)
        {
            return new ViewIssue() 
            {
                IdV = issue.Id,
                NameV = issue.Name,
                TextV = issue.Text,
                TypeV = issue.Type,
                IdTypeV = issue.IdType
            };
        }

        public Issue ToIssue(ViewIssue issueV)
        {
            return new Issue() 
            {
                Id = issueV.IdV,
                Name = issueV.NameV,
                Text = issueV.TextV,
                Type = issueV.TypeV,
                IdType = issueV.IdTypeV
            };
        }
    }
}