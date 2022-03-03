using Muleki.Domain.Entities;

namespace Muleki.Infra.Interfaces
{
    public interface IBaseRepository<T> where T : BaseEntity
    {
        Task<T> Create(T entity);
        Task<T> Update(T entity);
        Task Remove(long id);
        Task<T> FindById(long id);
        Task<List<T>> FindAll();
    }
}