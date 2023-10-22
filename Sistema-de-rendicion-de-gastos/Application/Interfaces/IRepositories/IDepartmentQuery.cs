using Domain.Entities;

namespace Application.Interfaces.IRepositories
{
    public interface IDepartmentQuery
    {
        Task<IEnumerable<Department>> GetDepartments();
        Task<Department> GetDepartment(int departmentId);
        Task<bool> ExistDepartment(int departmentId);
    }
}
