using System.ComponentModel.DataAnnotations;
using System.Data.Entity.ModelConfiguration;

namespace Mvckarolnew.Models.Mapping
{
    public class TypeToTypeMap : EntityTypeConfiguration<TypeToType>
    {
        public TypeToTypeMap()
        {
            // Primary Key
            this.HasKey(t => t.Id);

            // Properties
            this.Property(t => t.Id)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            // Table & Column Mappings
            this.ToTable("TypeToType");
            this.Property(t => t.Id).HasColumnName("Id");
            this.Property(t => t.IdParent).HasColumnName("IdParent");
            this.Property(t => t.IdSub).HasColumnName("IdSub");

            // Relationships
            this.HasRequired(t => t.Type)
                .WithMany(t => t.TypeToTypes)
                .HasForeignKey(d => d.IdParent);
            this.HasRequired(t => t.Type1)
                .WithMany(t => t.TypeToTypes1)
                .HasForeignKey(d => d.IdSub);

        }
    }
}
