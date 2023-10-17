using Application.DTO.Creator;
using Application.DTO.Request;
using Application.DTO.Response;
using Application.Exceptions;
using Application.Interfaces.IRepositories;
using Application.Interfaces.IServices;
using Domain.Entities;

namespace Application.UseCases
{
    public class CompanyService : ICompanyService
    {
        private readonly ICompanyQuery _query;
        private readonly CompanyCreator _creator;
        private readonly ICompanyCommand _command;

        public CompanyService(ICompanyQuery repository, ICompanyCommand command)
        {
            _query = repository;
            _creator = new CompanyCreator();
            _command = command;
        }

        public async Task<IList<CompanyResponse>> GetCompanys()
        {
            IList<CompanyResponse> list = new List<CompanyResponse>();
            IList<Company> entities = await _query.GetCompanys();

            foreach (Company entity in entities)
            {
                list.Add(_creator.Create(entity));
            }

            return list;
        }
        
        public async Task<CompanyResponse>? GetCompany(int companyId)
        {
            Company entity = await _query.GetCompany(companyId);

            if(entity == null)
                throw new NotFoundException("el id no corresponde a una compania.");

            return _creator.Create(entity);           
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
