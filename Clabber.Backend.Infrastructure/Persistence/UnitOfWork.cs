using Clabber.Backend.Application.Abstractions;
using Clabber.Backend.Domain.Entities.Profile;
using System.Collections;

namespace Clabber.Backend.Infrastructure.Persistence
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _appContext;
        private readonly IdentityDbContext _identityContext;
        private readonly Hashtable _repositories = new();
        private bool _disposed = false;

        public UnitOfWork(ApplicationDbContext context, IdentityDbContext identityContext)
        {
            this._appContext = context;
            this._identityContext = identityContext;
        }

        public IRepository<T> Repository<T>() where T : class
        {
            var type = typeof(T);

            if (!_repositories.ContainsKey(type)) 
            {
                var genericRepoType = typeof(Repository<>);
                var newRepoInstance = (type == typeof(Account) || type == typeof(Verification))
                    ? Activator.CreateInstance(genericRepoType.MakeGenericType(type), _identityContext) 
                    : Activator.CreateInstance(genericRepoType.MakeGenericType(type), _appContext);
                _repositories.Add(type, newRepoInstance);
            }

            return (IRepository<T>)_repositories[type]!;
        }

        public int Commit()
        {
            return _appContext.SaveChanges();
        }

        public async Task<int> CommitAsync()
        {
            return await _appContext.SaveChangesAsync();
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!this._disposed)
            {
                if (disposing)
                {
                    _appContext.Dispose();
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
