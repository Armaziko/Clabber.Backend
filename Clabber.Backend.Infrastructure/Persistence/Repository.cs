using Clabber.Backend.Application.Abstractions;
using Clabber.Backend.Application.Specification;
using Microsoft.EntityFrameworkCore;

namespace Clabber.Backend.Infrastructure.Persistence
{
    public class Repository<T> : IRepository<T> where T : class
    {
        protected readonly ApplicationDbContext _dbContext;
        private readonly DbSet<T> _dbSet;

        public Repository(ApplicationDbContext dbContext)
        {
            this._dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
            this._dbSet = dbContext.Set<T>();
        }
        public void Add(T item)
        {
            _dbSet.Add(item);
        }

        public void AddRange(IEnumerable<T> items)
        {
            _dbSet.AddRange(items);
        }

        public async Task<IReadOnlyList<T>> GetAllAsync(ISpecification<T>? specification = null)
        {
            IQueryable<T> query = _dbSet;
            query = SpecificationEvaluator.GetQuery(query, specification);
            return await query.ToListAsync();
        }

        public async Task<T?> GetByIdAsync(Guid id, ISpecification<T>? specification = null)
        {
            IQueryable<T> query = _dbSet;
            query = SpecificationEvaluator.GetQuery(query, specification);
            return await query.FirstOrDefaultAsync();
        }

        public void Remove(T item)
        {
            _dbSet.Remove(item);
        }

        public void Update(T item)
        {
            _dbSet.Update(item);
        }
    }
}
