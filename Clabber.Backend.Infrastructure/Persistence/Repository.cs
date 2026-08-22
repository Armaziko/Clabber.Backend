using Clabber.Backend.Application.Abstractions;
using Clabber.Backend.Application.Specification;
using Microsoft.EntityFrameworkCore;

namespace Clabber.Backend.Infrastructure.Persistence
{
    public class Repository<T> : IRepository<T> where T : class
    {
        protected readonly ApplicationDbContext? _dbContext;
        protected readonly IdentityDbContext? _identityContext;
        private readonly DbSet<T> _dbSet;

        public Repository(ApplicationDbContext dbContext)
        {
            this._dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
            this._dbSet = dbContext.Set<T>();
        }
        public Repository(IdentityDbContext identityContext)
        {
            this._identityContext = identityContext ?? throw new ArgumentNullException(nameof(identityContext));
            this._dbSet = identityContext.Set<T>();
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

        public async Task<IReadOnlyList<T>?> GetPageAsync(int page = 0, int limit = 8, ISpecification<T>? specification = null)
        {
            if (page < 0 || limit <= 0)
                return null;

            IQueryable<T> query = _dbSet;
            query = SpecificationEvaluator.GetQuery(query, specification).Skip(page*limit).Take(limit);
            IReadOnlyList<T>? list = await query.ToListAsync();
            return list;
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
