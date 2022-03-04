using Muleki.Domain.Entities;

namespace Muleki.Infra.Interfaces
{
    public interface IFootballRepository : IBaseRepository<Football>
    {
        Task<List<Football>> FindByDate(DateTime date);
        Task<List<Player>> FindPlayers(long footballId);
    }
}