using Application.Interfaces.IRepositories;
using Domain.Entities;
using Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.Design;

namespace Infrastructure
{
    public class DepartmentQuery : IDepartmentQuery
    {
        private ReportsDbContext _dbContext;

        public DepartmentQuery(ReportsDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public Department? GetDepartment(int departmentId)
        {
            var list = _dbContext.Set<Department>().Where(x => x.DepartmentId == departmentId).ToList();
            if(list.Count > 0) 
                return list[0];
            return null;
        }

        public IList<Department> GetDepartments()
        {
            return _dbContext.Set<Department>().ToList();
        }
    }
}
