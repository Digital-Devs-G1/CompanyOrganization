using Application.DTO.Response;
using Domain.Entities;

namespace Application.Interfaces.IRepositories
{
    public interface ICompanyQuery
    {
        Task<IList<Company>> GetCompanys();
        Task<Company>? GetCompany(int companyId);
    }
}
