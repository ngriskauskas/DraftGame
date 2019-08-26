using System.Linq;
using Draft.Core.Interfaces;
using Draft.Core.SharedKernel;
using Microsoft.EntityFrameworkCore;

namespace Draft.Inf.Data
{
    public static class SpecificationEvaluator<T> where T : Entity
    {
        public static IQueryable<T> GetQuery(IQueryable<T> inputQuery, ISpecification<T> specification)
        {
            var query = inputQuery;
            if (specification == null)
                return query;
            if (specification.Criteria != null)
                query = query.Where(specification.Criteria);

            query = specification.Includes
                .Aggregate(query, (current, include) => current.Include(include));

            query = specification.IncludeStrings
                .Aggregate(query, (current, include) => current.Include(include));

            return query;
        }

    }
}