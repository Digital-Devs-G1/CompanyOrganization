using Application.Interfaces.IRepositories;
using Domain.Entities;
using Infrastructure.Persistence;

namespace Infrastructure.Repositories.Commands
{
    public class EmployeeCommand : IEmployeeCommand
    {
        private readonly ReportsDbContext _dbContext;
        public EmployeeCommand(ReportsDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task AcceptApprovalsFlagFlag(Employee entity)
        {
            entity.ApprovalsFlag = true;
            _dbContext.SaveChanges();
        }

        public async Task AcceptHistoryFlag(Employee entity)
        {
            entity.HistoryFlag = true;
            _dbContext.SaveChanges();
        }

        public async Task DissmisApprovalsFlag(Employee entity)
        {
            entity.ApprovalsFlag = false;
            _dbContext.SaveChanges();
        }

        public async Task DissmisHistoryFlag(Employee entity)
        {
            entity.HistoryFlag = false;
            _dbContext.SaveChanges();
        }

        public async Task<int> DeleteEmployee(Employee employee)
        {
            _dbContext.Employees.Remove(employee);

            return await _dbContext.SaveChangesAsync();
        }

        public async Task<int> InsertEmployee(Employee employee)
        {
            _dbContext.Add(employee);
            return await _dbContext.SaveChangesAsync();
        }
    }
}
