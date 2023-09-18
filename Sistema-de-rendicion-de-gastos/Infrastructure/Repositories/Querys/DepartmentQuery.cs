using Application.Interfaces.IRepositories;
using Domain.Entities;
using Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.Design;

namespace Infrastructure.Repositories.Querys
{
    public class DepartmentQuery : IDepartmentQuery
    {
        private readonly ReportsDbContext _dbContext;

        public DepartmentQuery(ReportsDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<Department>? GetDepartment(int departmentId)
        {
            var list = await _dbContext.Set<Department>().Where(x => x.DepartmentId == departmentId).ToListAsync();
            if (list.Count > 0)
                return list[0];
            return null;
        }

        public async Task<IList<Department>> GetDepartments()
        {
            return await _dbContext.Set<Department>().ToListAsync();
        }
    }
}
