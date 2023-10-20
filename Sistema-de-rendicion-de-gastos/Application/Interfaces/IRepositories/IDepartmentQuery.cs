using Application.DTO.Response;
using Domain.Entities;

namespace Application.Interfaces.IRepositories
{
    public interface IDepartmentQuery
    {
        Task<IList<Department>> GetDepartments();
        Task<Department>? GetDepartment(int departmentId);

    }
}
