namespace SoundPromoMarketplace.Application.Abstractions
{
    public interface IUnitOfWork : IDisposable
    {
        public IRepository<T> Repository<T>() where T : class; 
        public int Commit();
        public Task<int> CommitAsync();
    }
}
