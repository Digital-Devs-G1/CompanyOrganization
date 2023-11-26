using Application.DTO.Request;
using Application.DTO.Response;

namespace Application.Interfaces.IServices
{
    public interface IPositionService
    {
        Task<List<PositionResponse>> GetPositionsByCompany(int company);
        Task<PositionResponse> GetPosition(int positionId);
        Task CreatePosition(PositionRequest request);
        Task DeletePosition(int id);
    }
}
