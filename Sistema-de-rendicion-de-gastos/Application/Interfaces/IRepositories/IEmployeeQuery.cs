using Domain.Entities;

namespace Application.Interfaces.IRepositories
{
    public interface IEmployeeQuery
    {
        Task<IEnumerable<Employee>> GetEmployees();
        Task<IEnumerable<Employee>> GetEmployeesByDepartment(int dep);
        Task<Employee> GetEmployee(int? employeeId);
        Task<Department> GetDepartmentByIdUser(int IdUser);
        public Task<Employee> GetEmployeeShallow(int? employeeId);
    }
}
