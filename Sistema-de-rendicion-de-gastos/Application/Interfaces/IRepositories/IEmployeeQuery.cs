using Application.DTO.Response;
using Domain.Entities;

namespace Application.Interfaces.IRepositories
{
    public interface IEmployeeQuery
    {
        Task<IList<Employee>> GetEmployees();
        Task<Employee>? GetEmployee(int employeeId);
    }
}
