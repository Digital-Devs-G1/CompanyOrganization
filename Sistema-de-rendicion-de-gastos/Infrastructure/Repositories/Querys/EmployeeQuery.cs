using Application.Interfaces.IRepositories;
using Domain.Entities;
using Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories.Querys
{
    public class EmployeeQuery : IEmployeeQuery
    {
        private readonly ReportsDbContext _dbContext;

        public EmployeeQuery(ReportsDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<Employee> GetEmployee(int employeeId)
        {
            return await _dbContext.Employees.FirstOrDefaultAsync(x => x.Id == employeeId);
        }

        public async Task<IList<Employee>> GetEmployees()
        {
            return await _dbContext.Set<Employee>().ToListAsync();
        }
    }
}