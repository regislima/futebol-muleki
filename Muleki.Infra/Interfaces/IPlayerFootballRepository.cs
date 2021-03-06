using Muleki.Domain.Entities;

namespace Muleki.Infra.Interfaces
{
    public interface IPlayerFootballRepository : IBaseRepository<PlayerFootball>
    {
        Task<PlayerFootball> RemovePlayer(Player player);
    }
}