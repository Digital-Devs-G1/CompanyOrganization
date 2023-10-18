using Application.Interfaces.IRepositories;
using Domain.Entities;
using Infrastructure.Persistence;

namespace Infrastructure.Repositories.Commands
{
    public class PayrollCommand : IPayrollCommand
    {
        private readonly ReportsDbContext _dbContext;
        public PayrollCommand(ReportsDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task InsertPayroll(Payroll payroll)
        {
            _dbContext.Add(payroll);
            await _dbContext.SaveChangesAsync();
        }
    }
}