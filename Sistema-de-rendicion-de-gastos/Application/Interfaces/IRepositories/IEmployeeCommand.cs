using Domain.Entities;

namespace Application.Interfaces.IRepositories
{
    public interface IEmployeeCommand
    {
        Task InsertEmployee(Employee employee);
    }
}
