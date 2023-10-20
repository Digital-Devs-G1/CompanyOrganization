using Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;


namespace Infrastructure.Persistence.Inserts
{
    public class EmployeeInserts : IEntityTypeConfiguration<Employee>
    {
        public void Configure(EntityTypeBuilder<Employee> builder)
        {
            builder.HasData(
                    new Employee()
                    {
                        Id = 1,
                        FirstName = "leo",
                        LastName = "messi",
                        DepartamentId = 1,
                        PositionId = 1
                    });
        }
    }
}

