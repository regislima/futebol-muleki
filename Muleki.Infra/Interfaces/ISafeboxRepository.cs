using Muleki.Domain.Entities;

namespace Muleki.Infra.Interfaces
{
    public interface ISafeboxRepository : IBaseRepository<Safebox>
    {
        Task<Safebox> FindByFootball(long footballId);
    }
}