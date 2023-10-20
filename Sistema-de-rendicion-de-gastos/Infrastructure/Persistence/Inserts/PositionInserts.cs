using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Persistence.Inserts
{
    public class PositionInserts : IEntityTypeConfiguration<Position>
    {
        public void Configure(EntityTypeBuilder<Position> builder)
        {
            builder.HasData(
                   new Position()
                   {
                       Id = 1,
                       Name = "Socio",
                       Hierarchy = 1,
                       MaxAmount = 500000,
                       IdCompany = 1,
                   },
                   new Position()
                   {
                       Id = 2,
                       Name = "Director",
                       Hierarchy = 10,
                       MaxAmount = 5000,
                       IdCompany = 1,
                   });
        }
    }
}
