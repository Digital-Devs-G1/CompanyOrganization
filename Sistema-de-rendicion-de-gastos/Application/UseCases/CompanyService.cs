using Application.DTO.Creator;
using Application.DTO.Request;
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
        private ICompanyCommand _command;

        public CompanyService(ICompanyQuery repository, ICompanyCommand command)
        {
            _repository = repository;
            _creator = new CompanyCreator();
            _command = command;
        }

        public async Task<IList<CompanyResponse>> GetCompanys()
        {
            IList<CompanyResponse> list = new List<CompanyResponse>();
            IList<Company> entities = await _repository.GetCompanys();
            foreach (Company entity in entities)
            {
                list.Add(_creator.Create(entity));
            }
            return list;
        }
        public async Task<CompanyResponse>? GetCompany(int companyId)
        {
            Company? entity = await _repository.GetCompany(companyId);
            if (entity != null)
                return _creator.Create(entity);
            return null;
        }
        public async Task<Company> CreateCompany(CompanyRequest request)
        {
            var company = new Company
            {
                Cuit = request.Cuit,
                Name = request.Name,
                Adress = request.Adress,
                Phone = request.Phone
            };
            await _command.InsertCompany(company);
            return company;
        }
    }
}
