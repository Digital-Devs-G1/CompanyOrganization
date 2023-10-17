using Application.Interfaces.IRepositories;
using Domain.Entities;
using Infrastructure.Persistence;

namespace Infrastructure.Repositories.Commands
{
    public class DepartmentCommand : IDepartmentCommand
    {
        private readonly ReportsDbContext _dbContext;

        public DepartmentCommand(ReportsDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task InsertDepartment(Department department)
        {
            _dbContext.Add(department);
            await _dbContext.SaveChangesAsync();
        }

    }
}
