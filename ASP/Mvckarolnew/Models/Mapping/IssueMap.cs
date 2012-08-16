using System.ComponentModel.DataAnnotations;
using System.Data.Entity.ModelConfiguration;

namespace Mvckarolnew.Models.Mapping
{
    public class IssueMap : EntityTypeConfiguration<Issue>
    {
        public IssueMap()
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
            this.ToTable("Issue");
            this.Property(t => t.Id).HasColumnName("Id");
            this.Property(t => t.IdType).HasColumnName("IdType");
            this.Property(t => t.Name).HasColumnName("Name");
            this.Property(t => t.Text).HasColumnName("Text");

            // Relationships
            this.HasOptional(t => t.Type)
                .WithMany(t => t.Issues)
                .HasForeignKey(t => t.IdType);


        }
    }
}
