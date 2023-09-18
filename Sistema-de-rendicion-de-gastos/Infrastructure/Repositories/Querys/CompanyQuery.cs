using Application.Interfaces.IRepositories;
using Domain.Entities;
using Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.Design;

namespace Infrastructure.Repositories.Querys
{
    public class CompanyQuery : ICompanyQuery
    {
        private readonly ReportsDbContext _dbContext;

        public CompanyQuery(ReportsDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Company>? GetCompany(int companyId)
        {
            var list = await _dbContext.Set<Company>().Where(x => x.CompanyId == companyId).ToListAsync();
            if (list.Count > 0)
                return list[0];
            return null;
        }

        public async Task<IList<Company>> GetCompanys()
        {
            return await _dbContext.Set<Company>().ToListAsync();
        }
    }
}
