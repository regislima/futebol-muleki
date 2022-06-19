using Muleki.Service.Dto;

namespace Muleki.Service.Interfaces
{
    public interface IPlayerFootballService : IBaseService<PlayerFootballDto>
    {
        Task<PlayerFootballDto> RemovePlayer(long playerId);
    }
}