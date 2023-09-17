using Application.DTO.Creator;
using Application.DTO.Response;
using Application.Interfaces.IRepositories;
using Application.Interfaces.IServices;
using Domain.Entities;

namespace Application.UseCases
{
    public class CompanyService : ICompanyService
    {
        private ICompanyQuery _repository;
        private CompanyCreator _creator;

        public CompanyService(ICompanyQuery repository)
        {
            _repository = repository;
            _creator = new CompanyCreator();
        }

        public IList<CompanyResponse> GetCompanys()
        {
            IList<CompanyResponse> list = new List<CompanyResponse>();
            IList<Company> entities = _repository.GetCompanys();
            foreach (Company entity in entities)
            {
                list.Add(_creator.Create(entity));
            }
            return list;
        }
        public CompanyResponse? GetCompany(int companyId)
        {
            Company? entity = _repository.GetCompany(companyId);
            if(entity != null)
               return _creator.Create(entity);
            return null;            
        }

    }
}
