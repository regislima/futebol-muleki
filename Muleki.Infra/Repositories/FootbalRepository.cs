using Microsoft.EntityFrameworkCore;
using Muleki.Domain.Entities;
using Muleki.Infra.Context;
using Muleki.Infra.Interfaces;

namespace Muleki.Infra.Repositories
{
    public class FootbalRepository : BaseRepository<Football>, IFootballRepository
    {
        public FootbalRepository(MulekiContext context, IUnitOfWork unitOfWork) : base(context, unitOfWork) { }

        public async Task<Football> FindByDate(DateTime date)
        {
            return await _context.Footballs.Where(football => football.Created_At.Equals(date))
                .AsNoTracking()
                .FirstOrDefaultAsync();
        }
    }
}