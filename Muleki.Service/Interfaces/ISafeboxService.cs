using Muleki.Service.Dto;

namespace Muleki.Service.Interfaces
{
    public interface ISafeboxService : IBaseService<SafeboxDto>
    {
        Task<SafeboxDto> FindByFootballId(long footballId);
    }
}