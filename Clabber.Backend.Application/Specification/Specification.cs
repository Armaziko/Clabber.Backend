using System.Linq.Expressions;

namespace Clabber.Backend.Application.Specification
{
    public class Specification<T>
    {
        public List<Expression<Func<T, object>>> Includes { get; }

        public Expression<Func<T, bool>>? Criteria { get; }

        public bool AsNoTracking { get; private set; } = false;

        public Specification(Expression<Func<T, bool>>? criteria = null)
        {
            this.Criteria = criteria;
            this.Includes = [];
        }

        public void AddInclude(Expression<Func<T, object>> include)
        {
            this.Includes.Add(include);
        }

        public void AsNoTrackingQuery()
        {
            this.AsNoTracking = true;
        }
    }
}
