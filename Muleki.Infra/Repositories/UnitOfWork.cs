using Muleki.Infra.Context;
using Muleki.Infra.Interfaces;

namespace Muleki.Infra.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly MulekiContext _context;

        public UnitOfWork(MulekiContext context)
        {
            _context = context;
        }

        public async Task CompleteAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}