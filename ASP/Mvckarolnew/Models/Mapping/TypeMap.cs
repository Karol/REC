using System.ComponentModel.DataAnnotations;
using System.Data.Entity.ModelConfiguration;

namespace Mvckarolnew.Models.Mapping
{
    public class TypeMap : EntityTypeConfiguration<Type>
    {
        public TypeMap()
        {
            // Primary Key
            this.HasKey(t => t.Id);

            // Properties
            this.Property(t => t.Id)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            this.Property(t => t.Name)
                .IsRequired()
                .HasMaxLength(50);

            // Table & Column Mappings
            this.ToTable("Type");
            this.Property(t => t.Id).HasColumnName("Id");
            this.Property(t => t.Name).HasColumnName("Name");
        }
    }
}
