namespace Muleki.Infra.Interfaces
{
    public interface IUnitOfWork
    {
        Task CompleteAsync();
    }
}