using EduConnect.Domain.Entities.Common;

namespace EduConnect.Application.Abstractions.Interfaces.Persistence
{
    public interface IUnitOfWork : IAsyncDisposable
    {
        IGenericRepository<T>? Repository<T>() where T : BaseEntity;
        Task<int> SaveAsync();
    }
}
