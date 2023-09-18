using Application.DTO.Response;
using Domain.Entities;

namespace Application.Interfaces.IRepositories
{
    public interface ICompanyCommand
    {   
        Task InsertCompany(Company company);
    }
}
