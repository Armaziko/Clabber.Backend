namespace SoundPromoMarketplace.Application.Abstractions
{
    public interface IRepository<T> where T : class
    {
        public void Add(T item);
        public void AddRange(IEnumerable<T> items);

        public Task<T?> GetByIdAsync(Guid id);
        public Task<IEnumerable<T>> GetAllAsync();

        public void Update(T item);
        public void Remove(T item);
    }
}
