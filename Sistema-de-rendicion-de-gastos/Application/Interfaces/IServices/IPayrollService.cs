using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.DTO.Request;
using Application.DTO.Response;
using Domain.Entities;

namespace Application.Interfaces.IServices
{
    public interface IPayrollService
    {
      //  public IList<PayrollResponse> GetPayroll();
      //  public PayrollResponse? GetPayroll(int payrollId);
        Task<IList<PayrollResponse>> GetPayrolls();
        Task<PayrollResponse>? GetPayroll(int payrollId);
        Task<Payroll> CreatePayroll(PayrollRequest request);
    }
}