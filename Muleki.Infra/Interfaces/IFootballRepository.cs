using Muleki.Domain.Entities;

namespace Muleki.Infra.Interfaces
{
    public interface IFootballRepository : IBaseRepository<Football>
    {
        Task<Football> FindByDate(DateTime date);
    }
}