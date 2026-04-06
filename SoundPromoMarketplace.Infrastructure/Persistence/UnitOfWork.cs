using SoundPromoMarketplace.Application.Abstractions;
using SoundPromoMarketplace.Domain.Entities;
using System.Collections;

namespace SoundPromoMarketplace.Infrastructure.Persistence
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _context;
        private readonly Hashtable _repositories = new();

        public UnitOfWork(ApplicationDbContext context)
        {
            this._context = context;
        }

        public IRepository<T> Repository<T>() where T : class
        {
            var type = typeof(T);

            if (!_repositories.ContainsKey(type)) 
            {
                var genericRepoType = typeof(Repository<>);
                var newRepoInstance = Activator.CreateInstance(genericRepoType.MakeGenericType(typeof(T)), _context);
                _repositories.Add(type, newRepoInstance);
            }

            return (IRepository<T>)_repositories[type]!;
        }

        public Task<int> Commit()
        {
            return _context.SaveChanges();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
