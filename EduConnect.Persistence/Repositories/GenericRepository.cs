using EduConnect.Application.Abstractions.Interfaces.Persistence;
using EduConnect.Domain.Entities.Common;
using Microsoft.EntityFrameworkCore;

namespace EduConnect.Persistence.Repositories
{
    public class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : BaseEntity
    {
        protected readonly ApplicationDbContext _context;

        public GenericRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IReadOnlyList<TEntity>> GetAllAsync() => await _context.Set<TEntity>().ToListAsync();

        public async Task<TEntity> GetEntityAsync(Guid id) => await _context.Set<TEntity>().FindAsync(id);

        public void Create(TEntity entity) => _context.Set<TEntity>().Add(entity);

        public void Delete(TEntity entity) => _context.Set<TEntity>().Remove(entity);

        public void Update(TEntity entity) => _context.Set<TEntity>().Update(entity);
    }
}
