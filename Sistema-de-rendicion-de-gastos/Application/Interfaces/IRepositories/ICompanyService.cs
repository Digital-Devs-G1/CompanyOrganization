using Application.DTO.Response;
using Domain.Entities;

namespace Application.Interfaces.IRepositories
{
    public interface ICompanyQuery
    {
        public IList<Company> GetCompanys();
        public Company? GetCompany(int companyId);
    }
}
