namespace Muleki.Service.Interfaces
{
    public interface IBaseService<T>
    {
        Task<T> Create(T objDto);
        Task<T> Update(T objDTO);
        Task Remove(long id);
        Task<T> FindById(long id);
        Task<List<T>> FindAll();
    }
}