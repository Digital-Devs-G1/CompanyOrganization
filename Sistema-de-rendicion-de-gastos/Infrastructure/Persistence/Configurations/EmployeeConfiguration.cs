using Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Persistence.Configurations
{
    public class EmployeeConfiguration : IEntityTypeConfiguration<Employee>
    {
        public void Configure(EntityTypeBuilder<Employee> builder)
        {
            builder.HasKey(x => x.EmployeeId);
            builder.Property(x => x.EmployeeId).ValueGeneratedOnAdd();
            builder.Property(x => x.EmployeeId).IsRequired();
            builder.Property(x => x.JobId).IsRequired();
            builder.Property(x => x.UserId).IsRequired();
            builder.Property(x => x.FirsName).HasMaxLength(30).IsRequired();
            builder.Property(x => x.LastName).HasMaxLength(30).IsRequired();
            builder.Property(x => x.Phone).HasMaxLength(12).IsRequired();
            builder.Property(x => x.Sex).HasMaxLength(20).IsRequired();
            builder.Property(x => x.CivilStatus).HasMaxLength(50).IsRequired();

            builder.Property(x => x.Dni).IsRequired();

            builder.HasMany<Payroll>()
                .WithOne(z => z.EmployeeNav)
                .HasForeignKey(z => z.EmployeeId);
        }
    }
}

