using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace MvcKarol.Models
{
    public class TablesContext :DbContext
    {
        public DbSet<TbType> TbTypes { get; set; }
        public DbSet<TbIssue> TbIssues { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }

    }
}