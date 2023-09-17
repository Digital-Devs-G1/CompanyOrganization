using Application.Interfaces.IRepositories;
using Domain.Entities;
using Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.Design;

namespace Infrastructure
{
    public class CompanyQuery : ICompanyQuery
    {
        private ReportsDbContext _dbContext;

        public CompanyQuery(ReportsDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public Company? GetCompany(int companyId)
        {
            var list = _dbContext.Set<Company>().Where(x => x.CompanyId == companyId).ToList();
            if(list.Count > 0) 
                return list[0];
            return null;
        }

        public IList<Company> GetCompanys()
        {
            return _dbContext.Set<Company>().ToList();
        }
    }
}
