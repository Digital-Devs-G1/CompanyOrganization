using Application.DTO.Response;
using Domain.Entities;

namespace Application.Interfaces.IRepositories
{
    public interface IDepartmentCommand
    {
        Task InsertDepartment(Department department);
    }
}
