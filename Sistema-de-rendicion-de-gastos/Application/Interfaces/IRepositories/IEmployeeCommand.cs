using Domain.Entities;

namespace Application.Interfaces.IRepositories
{
    public interface IEmployeeCommand
    {
        Task DeleteEmployee(Employee employee);
        Task InsertEmployee(Employee employee);
    }
}
