using Application.DTO.Request;
using Application.DTO.Response;
using Domain.Entities;

namespace Application.Interfaces.IServices
{
    public interface IDepartmentService
    {
        Task<IList<DepartmentResponse>> GetDepartments();
        Task<DepartmentResponse>? GetDepartment(int departmentId);
        Task CreateDepartment(DepartmentRequest request);
        Task DeleteDepartment(int id);
    }
}
