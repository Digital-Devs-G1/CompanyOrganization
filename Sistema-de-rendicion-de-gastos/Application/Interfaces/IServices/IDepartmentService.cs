using Application.DTO.Request;
using Application.DTO.Response;

namespace Application.Interfaces.IServices
{
    public interface IDepartmentService
    {
        Task<IList<DepartmentResponse>> GetDepartmentsByCompany(int idCompany);
        Task<DepartmentResponse>? GetDepartment(int departmentId);
        Task CreateDepartment(DepartmentRequest request);
        Task DeleteDepartment(int id);
    }
}
