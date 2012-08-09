using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using MvcKarol.Models;

namespace MvcKarol.DAL
{
    public class TablesInitializer : DropCreateDatabaseIfModelChanges<TablesContext>
    {
                
             protected override void Seed(TablesContext context)
        {
            var typs = new List<TbType>
            {
                new TbType { TbTypeID=1, Name = "Pierwsza pozycja" }

            };
            typs.ForEach(s => context.TbTypes.Add(s));
            context.SaveChanges();

            var issues = new List<TbIssue>
            {
                new TbIssue {TbIssueID=1, Name = "Problem1", Text ="pierwszy problem typ1",TbType=typs[0] }
            };
            issues.ForEach(s => context.TbIssues.Add(s));
            context.SaveChanges();
        }
    }

}