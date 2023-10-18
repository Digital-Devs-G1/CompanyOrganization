using Application.Interfaces.IRepositories;
using Domain.Entities;
using Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories.Querys
{
    public class PayrollQuery : IPayrollQuery
    {
        private readonly ReportsDbContext _dbContext;
        public PayrollQuery(ReportsDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<Payroll>? GetPayroll(int payrollId)
        {
            var list = await _dbContext.Set<Payroll>().Where(x => x.PayrollId == payrollId).ToListAsync();
            if (list.Count > 0)
                return list[0];
            return null;
        }
        public async Task<IList<Payroll>> GetPayrolls()
        {
            return await _dbContext.Set<Payroll>().ToListAsync();
        }
    }
}
