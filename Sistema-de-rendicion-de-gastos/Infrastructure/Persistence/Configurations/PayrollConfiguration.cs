using Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace Infrastructure.Persistence.Configurations
{
    public class PayrollConfiguration : IEntityTypeConfiguration<Payroll>
    {
        public void Configure(EntityTypeBuilder<Payroll> builder)
        {
            builder.HasKey(e => e.PayrollId);

            builder.HasOne(c => c.CompanyNav)
                   .WithMany()
                   .HasForeignKey(c => c.CompanyId);

            builder.HasOne(d => d.DepartmentNav)
                   .WithMany()
                   .HasForeignKey(d => d.DepartmentId);

            builder.HasOne(d => d.DepartmentNav)
                   .WithMany()
                   .HasForeignKey(d => d.DepartmentId);

            builder.HasOne(x => x.PositionNav)
                   .WithMany()
            .HasForeignKey(x => x.PositionId);

            builder.HasOne(x => x.EmployeeNav)
                   .WithMany()
                   .HasForeignKey(x => x.EmployeeId);
        }
    }
}
