using Muleki.Domain.Entities;
using Muleki.Infra.Context;
using Muleki.Infra.Interfaces;

namespace Muleki.Infra.Repositories
{
    public class PlayerFootballRepository : BaseRepository<PlayerFootball>
    {
        public PlayerFootballRepository(MulekiContext context, IUnitOfWork unitOfWork) : base(context, unitOfWork)
        { }
    }
}