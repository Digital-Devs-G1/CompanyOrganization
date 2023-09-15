using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Domain.Entities;

namespace Infrastructure.Persistence.Configurations
{
    public class DepartmentConfiguration : IEntityTypeConfiguration<Department>
    {
        public void Configure(EntityTypeBuilder<Department> builder)
        {
            builder.HasKey(e => e.DepartmentId);

            builder.Property(e => e.CompanyCuit)
                .IsRequired()
                .HasMaxLength(30);

            builder.Property(e => e.Name)
                .IsRequired()
                .HasMaxLength(30);

            builder.HasOne(rt => rt.CompanyNav)
               .WithMany(r => r.Departments)
               .HasForeignKey(rt => rt.CompanyCuit);

        }

    }

}
