using Application.Interfaces.IRepositories;
using Domain.Entities;
using Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

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
            return await _dbContext.Companys.FirstOrDefaultAsync(x => x.CompanyId == companyId);
        }

        public async Task<IList<Company>> GetCompanys()
        {
            return await _dbContext.Set<Company>().ToListAsync();
        }
    }
}