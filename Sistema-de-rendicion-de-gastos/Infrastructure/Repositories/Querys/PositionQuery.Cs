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

        public async Task<Position> GetPosition(int positionId)
        {
            return await _dbContext.Positions.FirstOrDefaultAsync(x => x.Id == positionId);
        }

        public async Task<IEnumerable<Position>> GetPositions()
        {
            return await _dbContext.Positions.ToListAsync();
        }
    }
}

