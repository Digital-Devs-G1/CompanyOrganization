using Application.DTO.Request;
using Application.DTO.Response;
using Domain.Entities;

namespace Application.Interfaces.IServices
{
    public interface IEmployeeService
    {
        Task<IList<EmployeeResponse>> GetEmployees();
        Task<EmployeeResponse>? GetEmployee(int employeeId);
        Task<Employee> CreateEmployee(EmployeeRequest request);
        Task<DepartmentResponse> GetDepartmentByIdUser(int idUser);
    }
}
