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

    public class PositionConfiguration : IEntityTypeConfiguration<Position>
    {
        public void Configure(EntityTypeBuilder<Position> builder)
        {
            builder.HasKey(x => x.PositionId);
            builder.Property(x => x.PositionId).ValueGeneratedOnAdd();
            builder.Property(x => x.Description).HasMaxLength(20).IsRequired();
            builder.Property(x => x.Hierarchy).IsRequired();
            builder.Property(x => x.MaxMonthlyAmount).IsRequired();

            builder.HasMany<Payroll>()
                   .WithOne(x => x.PositionNav)
                   .HasForeignKey(x => x.PositionId);
        }
    }
}