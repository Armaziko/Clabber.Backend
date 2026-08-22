using System.Linq.Expressions;

namespace Clabber.Backend.Application.Abstractions
{
    public interface ISpecification<T>
    {
        List<Expression<Func<T, object>>> Includes { get; }

        Expression<Func<T, bool>>? Criteria { get; }
        Expression<Func<T, object>>? OrderBy { get; }
        bool AsNoTracking { get; }
        void AddInclude(Expression<Func<T, object>> include);
        void AddOrderBy(Expression<Func<T, object>> orderBy); 
        void AsNoTrackingQuery();
    }
}