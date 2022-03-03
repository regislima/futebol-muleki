using Muleki.Domain.Entities;

namespace Muleki.Infra.Interfaces
{
    public interface IScoreRepository : IBaseRepository<Score>
    {
        Task<List<Score>> FindByPlayerId(long playerId);
    }
}