using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using Mvckarolnew.Models.Mapping;

namespace Mvckarolnew.Models
{
    public class MvcContext : DbContext
    {
        static MvcContext()
        {
            Database.SetInitializer<MvcContext>(null);
        }

		public MvcContext()
			: base("Name=MvcContext")
		{
		}

        public DbSet<Issue> Issues { get; set; }
        public DbSet<Type> Types { get; set; }
        public DbSet<TypeToType> TypeToTypes { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new IssueMap());
            modelBuilder.Configurations.Add(new TypeMap());
            modelBuilder.Configurations.Add(new TypeToTypeMap());
        }
    }
}
