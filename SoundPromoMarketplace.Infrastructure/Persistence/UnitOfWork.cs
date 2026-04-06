using SoundPromoMarketplace.Application.Abstractions;
using System.Collections;

namespace SoundPromoMarketplace.Infrastructure.Persistence
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _context;
        private readonly Hashtable _repositories = new();
        private bool _disposed = false;

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

        public int Commit()
        {
            return _context.SaveChanges();
        }

        public async Task<int> CommitAsync()
        {
            return await _context.SaveChangesAsync();
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!this._disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
                }
                _disposed = true;
            }
        }

        public void Dispose()
        {
            this.Dispose(true);

            GC.SuppressFinalize(this);
        }
    }
}
