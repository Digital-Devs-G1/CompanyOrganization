using Application.DTO.Response;
using Domain.Entities;

namespace Application.Interfaces.IRepositories
{
    public interface IPayrollQuery
    {
        //  public IList<Payroll> GetPayrolls();
        //   public Payroll? GetPayroll(int payrollId);

        Task<IList<Payroll>> GetPayrolls();
        Task<Payroll>? GetPayroll(int payrollId);
    }
}

