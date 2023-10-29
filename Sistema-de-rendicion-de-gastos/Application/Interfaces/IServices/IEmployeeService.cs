using Application.DTO.Request;
using Application.DTO.Response;

namespace Application.Interfaces.IServices
{
    public interface IEmployeeService
    {
        Task<List<EmployeeResponse>> GetEmployees();
        Task<EmployeeResponse> GetEmployee(int employeeId);
        Task CreateEmployee(EmployeeRequest request);
        Task<int?> NextApprover(int? id, int monto);
        Task<DepartmentResponse> GetDepartmentByIdUser(int idUser);
    }
}
