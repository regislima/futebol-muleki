using Microsoft.EntityFrameworkCore;
using Muleki.Domain.Entities;
using Muleki.Infra.Context;
using Muleki.Infra.Interfaces;

namespace Muleki.Infra.Repositories
{
    public class PlayerRepository : BaseRepository<Player>, IPlayerRepository
    {
        private readonly MulekiContext _context;
        private readonly IUnitOfWork _unitOfWork;

        public PlayerRepository(MulekiContext context, IUnitOfWork unitOfWork) : base(context, unitOfWork)
        {
            _context = context;
            _unitOfWork = unitOfWork;
        }

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

        public Task<List<Score>> FindScores(long playerId)
        {
            throw new NotImplementedException();
        }
    }
}