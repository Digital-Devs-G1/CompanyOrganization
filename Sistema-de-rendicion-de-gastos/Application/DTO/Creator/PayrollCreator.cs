using Application.DTO.Response;
using Domain.Entities;

namespace Application.DTO.Creator
{
    public class PayrollCreator
    {
        public PayrollResponse Create(Payroll payroll)
        {
            return new PayrollResponse()
            {
                PayrollId = payroll.PayrollId,
                CompanyId = payroll.CompanyId,
                DepartmentId = payroll.CompanyId,
                PositionId = payroll.PositionId,
                EmployeeId = payroll.EmployeeId,
            };
        }
    }
}