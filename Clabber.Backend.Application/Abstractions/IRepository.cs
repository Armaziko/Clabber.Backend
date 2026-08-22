namespace Clabber.Backend.Application.Abstractions
{
    public interface IRepository<T> where T : class
    {
        public void Add(T item);
        public void AddRange(IEnumerable<T> items);

        public Task<T?> GetByIdAsync(Guid id, ISpecification<T>? specification = null);
        public Task<IReadOnlyList<T>> GetAllAsync(ISpecification<T>? specification = null);
        public Task<IReadOnlyList<T>?> GetPageAsync(int page = 0, int limit = 4, ISpecification<T>? specification = null);
        public void Update(T item);
        public void Remove(T item);
    }
}
