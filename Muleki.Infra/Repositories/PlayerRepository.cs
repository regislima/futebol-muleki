using Microsoft.EntityFrameworkCore;
using Muleki.Domain.Entities;
using Muleki.Infra.Context;
using Muleki.Infra.Interfaces;

namespace Muleki.Infra.Repositories
{
    public class PlayerRepository : BaseRepository<Player>, IPlayerRepository
    {
        public PlayerRepository(MulekiContext context, IUnitOfWork unitOfWork) : base(context, unitOfWork) 
        { }

        public async Task<Player> FindByEmail(string email)
        {
            return await _context.Players.Where(player => player.Email.Equals(email))
                .AsNoTracking()
                .FirstOrDefaultAsync();
        }

        public async Task<List<Player>> FindByName(string name)
        {
            return await _context.Players.Where(player => player.Name.Contains(name))
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<List<Player>> FindByNick(string nick)
        {
            return await _context.Players.Where(player => player.Nick.Contains(nick))
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<List<Football>> FindFootballs(long playerId)
        {
            var idList = await _context.PlayersFootballs.Where(player => player.PlayerId == playerId)
                .AsNoTracking()
                .Select(player => player.FootballId)
                .ToListAsync();
            
            return await _context.Footballs.Where(football => idList.Contains(football.Id))
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<List<Score>> FindScores(long playerId)
        {
            var idList = await _context.PlayersFootballs.Where(player => player.PlayerId == playerId)
                .AsNoTracking()
                .Select(player => player.FootballId)
                .ToListAsync();
            
            return await _context.Scores.Where(score => idList.Contains(score.Id))
                .AsNoTracking()
                .ToListAsync();
        }
    }
}