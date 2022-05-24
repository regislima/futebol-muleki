using Microsoft.EntityFrameworkCore;
using Muleki.Domain.Entities;
using Muleki.Infra.Context;
using Muleki.Infra.Interfaces;

namespace Muleki.Infra.Repositories
{
    public abstract class BaseRepository<T> : IBaseRepository<T> where T : BaseEntity
    {
        protected readonly MulekiContext _context;
        protected readonly IUnitOfWork _unitOfWork;

        public BaseRepository(MulekiContext context, IUnitOfWork unitOfWork)
        {
            _context = context;
            _unitOfWork = unitOfWork;
        }

        public virtual async Task<T> Create(T entity)
        {
            _context.Add(entity);
            await _unitOfWork.CompleteAsync();

            return entity;
        }

        public virtual async Task<List<T>> FindAll()
        {
            return await _context.Set<T>()
                .AsNoTracking()
                .ToListAsync();
        }

        public virtual async Task<T> FindById(long id)
        {
            return await _context.Set<T>()
                .AsNoTracking()
                .Where(x => x.Id == id)
                .FirstAsync();
        }

        public virtual async Task Remove(T entity)
        {
            _context.Remove(entity);
            await _unitOfWork.CompleteAsync();
        }

        public virtual async Task<T> Update(T entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
            await _unitOfWork.CompleteAsync();

            return entity;
        }
    }
}