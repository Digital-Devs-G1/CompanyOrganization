using Application.Interfaces.IRepositories;
using Domain.Entities;
using Infrastructure.Persistence;

namespace Infrastructure.Repositories.Commands
{
    public class PositionCommand : IPositionCommand
    {
        private readonly ReportsDbContext _dbContext;
        public PositionCommand(ReportsDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task InsertPosition(Position position)
        {
            _dbContext.Add(position);
            await _dbContext.SaveChangesAsync();
        }
    }
}
