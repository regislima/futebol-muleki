using Muleki.Domain.Entities;

namespace Muleki.Infra.Interfaces
{
    public interface ISafeboxRepository : IBaseRepository<Safebox>
    {
        Task<Safebox> FindByFootballId(long footballId);
    }
}