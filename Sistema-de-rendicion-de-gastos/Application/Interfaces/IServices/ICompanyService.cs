using Application.DTO.Response;

namespace Application.Interfaces.IServices
{
    public interface ICompanyService
    {
        public IList<CompanyResponse> GetCompanys();
        public CompanyResponse? GetCompany(int companyId); 
    }
}
