using System.Linq;

using Skinet.Storage.Core.Specifications;

namespace Skinet.Storage.Core
{
    class SpecificationEvaluatorCriteria<TEntity> where TEntity : BaseEntityDto
    {
        public static IQueryable<TEntity> GetQuery(IQueryable<TEntity> inputQuery,
            ISpecification<TEntity> spec)
        {
            var query = inputQuery;

            if (spec.Criteria != null)
            {
                query = query.Where(spec.Criteria);
            }

            return query;
        }
    }
}
