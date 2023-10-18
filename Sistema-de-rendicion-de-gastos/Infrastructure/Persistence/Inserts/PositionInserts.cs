using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Persistence.Inserts
{
    public class PositionInserts : IEntityTypeConfiguration<Position>
    {
        public void Configure(EntityTypeBuilder<Position> builder)
        {
            builder.HasData(
                   new Position()
                   {
                       PositionId = 1,
                       Description = "Socio",
                       Hierarchy = 1,
                       MaxMonthlyAmount = 500000
                   },
                   new Position
                   {
                       PositionId = 2,
                       Description = "Director",
                       Hierarchy = 10,
                       MaxMonthlyAmount = 50000
                   },
                   new Position()
                   {
                       PositionId = 3,
                       Description = "Gerente",
                       Hierarchy = 20,
                       MaxMonthlyAmount = 10000
                   },
                   new Position()
                   {
                       PositionId = 4,
                       Description = "Supervisor",
                       Hierarchy = 30,
                       MaxMonthlyAmount = 1000
                   },
                   new Position()
                   {
                       PositionId = 5,
                       Description = "Lider",
                       Hierarchy = 40,
                       MaxMonthlyAmount = 100
                   });
        }
    }
}
