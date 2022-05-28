using Muleki.Service.Dto;

namespace Muleki.Service.Interfaces
{
    public interface IFootballService : IBaseService<FootballDto>
    {
        Task<FootballDto> FindByDate(DateTime date);
    }
}