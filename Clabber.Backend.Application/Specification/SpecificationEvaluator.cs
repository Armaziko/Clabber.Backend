using Microsoft.EntityFrameworkCore;

namespace Clabber.Backend.Application.Specification
{
    public static class SpecificationEvaluator
    {
        public static IQueryable<T> GetQuery<T>(IQueryable<T> query, Specification<T> specification)
            where T : class
        {
            if (specification.AsNoTracking)
            {
                query = query.AsNoTracking();
            }

            if (specification.Criteria is not null)
            {
                query = query.Where(specification.Criteria);
            }

            if (specification.Includes != null && specification.Includes.Count != 0)
            {
                foreach (var include in specification.Includes) 
                {
                    query = query.Include(include);
                }
            }

            return query;
        }
    }
}
