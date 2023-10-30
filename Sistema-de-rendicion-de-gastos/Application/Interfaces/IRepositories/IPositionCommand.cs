using Application.DTO.Response;
using Domain.Entities;

namespace Application.Interfaces.IRepositories
{
    public interface IPositionCommand
    {
        Task DeletePosition(Position entity);
        Task InsertPosition(Position position);
    }
}
