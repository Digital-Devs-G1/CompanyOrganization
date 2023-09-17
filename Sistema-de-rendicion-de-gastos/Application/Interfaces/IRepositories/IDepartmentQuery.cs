using Application.DTO.Response;
using Domain.Entities;

namespace Application.Interfaces.IRepositories
{
    public interface IDepartmentQuery
    {
        public IList<Department> GetDepartments();
        public Department? GetDepartment(int departmentId);
    }
}
