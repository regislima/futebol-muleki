using Muleki.Service.DTO;

namespace Muleki.Service.Interfaces
{
    public interface IPlayerService : IBaseService<PlayerDto>
    {
        Task<List<PlayerDto>> FindByName(string name);
        Task<List<PlayerDto>> FindByNick(string nick);
        Task<PlayerDto> FindByEmail(string email);
        Task<List<ScoreDto>> FindScores(long playerId);
        Task<List<FootballDto>> FindFootballs(long playerId);
    }
}