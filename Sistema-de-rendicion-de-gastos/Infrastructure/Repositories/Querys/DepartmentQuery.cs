using Application.Interfaces.IRepositories;
using Domain.Entities;
using Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories.Querys
{
    public class DepartmentQuery : IDepartmentQuery
    {
        private readonly ReportsDbContext _dbContext;

        public DepartmentQuery(ReportsDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Department> GetDepartment(int departmentId)
        {
            return await _dbContext.Departments.FirstOrDefaultAsync(d => d.Id == departmentId);
        }

        public async Task<IList<Department>> GetDepartments()
        {
            return await _dbContext.Set<Department>().ToListAsync();
        }
    }
}
