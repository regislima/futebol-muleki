namespace Muleki.Service.Interfaces
{
    public interface IBaseService<T>
    {
        Task<T> Create(T objDto);
        Task<T> Update(T objDto);
        Task<T> Remove(long id);
        Task<T> FindById(long id);
        Task<List<T>> FindAll();
    }
}