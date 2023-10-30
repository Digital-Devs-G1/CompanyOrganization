using Application.Interfaces.IRepositories;
using Domain.Entities;
using Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories.Commands
{
    public class DepartmentCommand : IDepartmentCommand
    {
        private readonly ReportsDbContext _dbContext;

        public DepartmentCommand(ReportsDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task DeleteDepartment(Department entity)
        {
            _dbContext.Departments.Remove(entity);
            await _dbContext.SaveChangesAsync();
        }

        public async Task InsertDepartment(Department department)
        {
            _dbContext.Add(department);
            await _dbContext.SaveChangesAsync();
        }

    }
}