using Muleki.Domain.Entities;

namespace Muleki.Infra.Interfaces
{
    public interface IPlayerRepository : IBaseRepository<Player>
    {
        Task<List<Player>> FindByName(string name);
        Task<List<Player>> FindByNick(string nick);
        Task<Player> FindByEmail(string email);
        Task<List<Score>> FindScores(long playerId);
    }
}