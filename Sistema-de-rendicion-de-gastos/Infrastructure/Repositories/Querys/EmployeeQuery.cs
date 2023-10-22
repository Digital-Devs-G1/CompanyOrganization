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

        public async Task<Department> GetDepartmentByIdUser(int IdUser)
        {
            return  await _dbContext.Employees
                            .Where(e => e.Id == IdUser)
                            .Select(e => e.Departament)
                            .FirstOrDefaultAsync();
        }

        public async Task<Employee> GetEmployee(int? employeeId)
        {
            return await _dbContext.Employees
                            .Include(x => x.Position)
                            .Include(x => x.Departament)
                            .FirstOrDefaultAsync(x => x.Id == employeeId);
        }

        public async Task<IEnumerable<Employee>> GetEmployees()
        {
            return await _dbContext.Employees.ToListAsync();
        }
    }
}