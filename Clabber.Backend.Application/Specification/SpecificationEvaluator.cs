using Clabber.Backend.Application.Abstractions;
using Microsoft.EntityFrameworkCore;

namespace Clabber.Backend.Application.Specification
{
    public static class SpecificationEvaluator
    {
        public static IQueryable<T> GetQuery<T>(IQueryable<T> query, ISpecification<T>? specification = null)
            where T : class
        {
            if (specification is null)
                return query;

            if (specification.AsNoTracking)
                query = query.AsNoTracking();

            if (specification.Criteria is not null)
                query = query.Where(specification.Criteria);

            if (specification.Includes != null && specification.Includes.Count != 0)
            {
                foreach (var include in specification.Includes) 
                {
                    query = query.Include(include);
                }
            }

            if (specification.OrderBy is not null)
            {
                query.OrderBy(specification.OrderBy);
            }

            return query;
        }
    }
}
