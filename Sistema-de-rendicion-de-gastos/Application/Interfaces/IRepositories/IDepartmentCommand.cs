using Application.DTO.Response;
using Domain.Entities;

namespace Application.Interfaces.IRepositories
{
    public interface IDepartmentCommand
    {
        Task DeleteDepartment(Department entity);
        Task InsertDepartment(Department department);
    }
}
