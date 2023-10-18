using Application.DTO.Response;
using Domain.Entities;

namespace Application.Interfaces.IRepositories
{
    public interface IPayrollCommand
    {
        Task InsertPayroll(Payroll payroll);
    }
}
