using Microsoft.EntityFrameworkCore;
using Muleki.Domain.Entities;
using Muleki.Infra.Context;
using Muleki.Infra.Interfaces;

namespace Muleki.Infra.Repositories
{
    public class SafeboxRepository : BaseRepository<Safebox>, ISafeboxRepository
    {
        public SafeboxRepository(MulekiContext context, IUnitOfWork unitOfWork) : base(context, unitOfWork) { }

        public async Task<Safebox> FindByFootballId(long footballId)
        {
            return await _context.SafeBoxes.Where(safebox => safebox.FootballId == footballId)
                .AsNoTracking()
                .FirstAsync();
        }
    }
}