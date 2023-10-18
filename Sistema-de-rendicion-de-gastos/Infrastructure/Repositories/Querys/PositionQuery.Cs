using Application.Interfaces.IRepositories;
using Domain.Entities;
using Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories.Querys
{
    public class PositionQuery : IPositionQuery
    {
        private readonly ReportsDbContext _dbContext;


        public PositionQuery(ReportsDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<Position>? GetPosition(int positionId)
        {
            var list = await _dbContext.Set<Position>().Where(x => x.PositionId == positionId).ToListAsync();
            if (list.Count > 0)
                return list[0];
            return null;
        }

        public async Task<IList<Position>> GetPositions()
        {
            return await _dbContext.Set<Position>().ToListAsync();
        }
    }
}

