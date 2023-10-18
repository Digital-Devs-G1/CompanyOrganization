using Application.Interfaces.IRepositories;
using Domain.Entities;
using Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.Design;

namespace Infrastructure.Repositories.Querys
{
    public class EmployeeQuery : IEmployeeQuery
    {
        private readonly ReportsDbContext _dbContext;

        public EmployeeQuery(ReportsDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<Employee>? GetEmployee(int employeeId)
        {
            var list = await _dbContext.Set<Employee>().Where(x => x.EmployeeId == employeeId).ToListAsync();
            if (list.Count > 0)
                return list[0];
            return null;
        }

        public async Task<IList<Employee>> GetEmployees()
        {
            return await _dbContext.Set<Employee>().ToListAsync();
        }
    }
}