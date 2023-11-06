using Application.DTO.Request;
using Application.DTO.Response;

namespace Application.Interfaces.IServices
{
    public interface IEmployeeService
    {
        Task<List<EmployeeResponse>> GetEmployees();
        Task<EmployeeResponse> GetEmployee(int employeeId);
        Task CreateEmployee(EmployeeRequest request);
        Task<int> NextApprover(int id);
        Task<DepartmentResponse> GetDepartmentByIdUser(int idUser);
        Task DeleteEmployee(int id);
        Task AcceptHistoryFlag(int id);
        Task DissmisHistoryFlag(int id);
        Task AcceptApprovalsFlagFlag(int id);
        Task DissmisApprovalsFlag(int id);
    }
}