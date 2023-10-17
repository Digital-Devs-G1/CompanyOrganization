using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Persistence.Configurations
{
    public class PayrollConfiguration : IEntityTypeConfiguration<Payroll>
    {
        public void Configure(EntityTypeBuilder<Payroll> builder)
        {
            builder.HasKey(e => e.PayrollId);
            builder.Property(e => e.PayrollId)
                    .ValueGeneratedOnAdd();

            builder.HasOne(c => c.CompanyNav)
                   .WithMany()
                   .HasForeignKey(c => c.CompanyId);

            builder.HasOne(d => d.DepartmentNav)
                   .WithMany()
                   .HasForeignKey(d => d.DepartmentId);

        }

    }
}
