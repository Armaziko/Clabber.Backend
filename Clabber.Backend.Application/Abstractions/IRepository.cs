namespace Clabber.Backend.Application.Abstractions
{
    public interface IRepository<T> where T : class
    {
        public void Add(T item);
        public void AddRange(IEnumerable<T> items);

        public Task<T?> GetByIdAsync(Guid id);
        public Task<IReadOnlyList<T>> GetAllAsync();

        public void Update(T item);
        public void Remove(T item);
    }
}
