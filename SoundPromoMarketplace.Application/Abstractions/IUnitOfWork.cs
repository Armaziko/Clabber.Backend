namespace SoundPromoMarketplace.Application.Abstractions
{
    public interface IUnitOfWork : IDisposable
    {
        public Task<int> Commit();
    }
}
