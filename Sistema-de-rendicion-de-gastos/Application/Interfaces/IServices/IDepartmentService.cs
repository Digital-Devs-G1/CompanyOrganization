using Application.DTO.Request;
using Application.DTO.Response;
using Domain.Entities;

namespace Application.Interfaces.IServices
{
    public interface IDepartmentService
    {
        Task<IList<DepartmentResponse>> GetDepartments();
        Task<DepartmentResponse>? GetDepartment(int departmentId);
        Task<Department> CreateDepartment(DepartmentRequest request);
    }
}
