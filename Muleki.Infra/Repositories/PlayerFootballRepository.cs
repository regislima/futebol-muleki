using Microsoft.EntityFrameworkCore;
using Muleki.Domain.Entities;
using Muleki.Infra.Context;
using Muleki.Infra.Interfaces;

namespace Muleki.Infra.Repositories
{
    public class PlayerFootballRepository : BaseRepository<PlayerFootball>, IPlayerFootballRepository
    {
        public PlayerFootballRepository(MulekiContext context, IUnitOfWork unitOfWork) : base(context, unitOfWork)
        { }

        public async Task<PlayerFootball> RemovePlayer(Player player)
        {
            PlayerFootball playerFootball =  await _context.PlayersFootballs.Where(pf => pf.PlayerId.Equals(player.Id))
                .AsNoTracking()
                .FirstAsync();

            _context.Remove(playerFootball);

            return playerFootball;
        }
    }
}