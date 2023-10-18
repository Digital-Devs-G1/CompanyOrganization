using Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistence.Inserts
{
    public class PayrollInserts : IEntityTypeConfiguration<Payroll>
    {
        public void Configure(EntityTypeBuilder<Payroll> builder)
        {
            builder.HasData(
                    new Payroll()
                    {
                        PayrollId = 1,
                        CompanyId = 1,
                        DepartmentId = 1,
                        PositionId = 1,
                        EmployeeId = 1
                    },
                    new Payroll()
                    {
                        PayrollId = 2,
                        CompanyId = 1,
                        DepartmentId = 2,
                        PositionId = 2,
                        EmployeeId = 2
                    },
                    new Payroll()
                    {
                        PayrollId = 3,
                        CompanyId = 1,
                        DepartmentId = 1,
                        PositionId = 3,
                        EmployeeId = 3
                    },
                    new Payroll()
                    {
                        PayrollId = 4,
                        CompanyId = 1,
                        DepartmentId = 2,
                        PositionId = 3,
                        EmployeeId = 4
                    },
                    new Payroll()
                    {
                        PayrollId = 5,
                        CompanyId = 1,
                        DepartmentId = 1,
                        PositionId = 4,
                        EmployeeId = 5
                    },
                    new Payroll()
                    {
                        PayrollId = 6,
                        CompanyId = 2,
                        DepartmentId = 2,
                        PositionId = 4,
                        EmployeeId = 6
                    },
                    new Payroll()
                    {
                        PayrollId = 7,
                        CompanyId = 1,
                        DepartmentId = 1,
                        PositionId = 4,
                        EmployeeId = 7
                    },
                    new Payroll()
                    {
                        PayrollId = 8,
                        CompanyId = 1,
                        DepartmentId = 1,
                        PositionId =5,
                        EmployeeId = 8
                    },
                    new Payroll()
                    {
                        PayrollId = 9,
                        CompanyId = 1,
                        DepartmentId = 1,
                        PositionId = 5,
                        EmployeeId = 9
                    },
                    new Payroll()
                    {
                        PayrollId = 10,
                        CompanyId = 1,
                        DepartmentId = 2,
                        PositionId = 5,
                        EmployeeId = 10
                    },
                    new Payroll()
                    {
                        PayrollId = 11,
                        CompanyId = 2,
                        DepartmentId = 1,
                        PositionId = 5,
                        EmployeeId = 11
                    });
        }
    }
}

