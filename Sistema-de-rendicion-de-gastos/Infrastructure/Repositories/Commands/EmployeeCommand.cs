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

        public async Task DeleteEmployee(Employee employee)
        {
            _dbContext.Employees.Remove(employee);

            _dbContext.SaveChangesAsync();
        }

        public async Task InsertEmployee(Employee employee)
        {
            _dbContext.Add(employee);
            await _dbContext.SaveChangesAsync();
        }
    }
}
