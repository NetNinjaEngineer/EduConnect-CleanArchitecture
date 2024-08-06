using EduConnect.Application.Abstractions.Interfaces.Persistence;
using EduConnect.Domain.Entities.Common;
using System.Collections;

namespace EduConnect.Persistence.Repositories
{
    public sealed class UnitOfWork(ApplicationDbContext context) : IUnitOfWork
    {
        private Hashtable _repositories = [];

        public async ValueTask DisposeAsync() => await context.DisposeAsync();

        public IGenericRepository<T>? Repository<T>() where T : BaseEntity
        {
            var typeName = typeof(T).Name;
            if (!_repositories.ContainsKey(typeName))
            {
                var repository = new GenericRepository<T>(context);
                _repositories.Add(typeName, repository);
                return repository;
            }

            return _repositories[typeName] as IGenericRepository<T>;

        }

        public async Task<int> SaveAsync() => await context.SaveChangesAsync();
    }
}
