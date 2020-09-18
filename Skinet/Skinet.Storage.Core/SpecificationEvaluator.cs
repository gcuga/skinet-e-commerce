﻿using System.Linq;

using Microsoft.EntityFrameworkCore;

using Skinet.Storage.Core.Specifications;

namespace Skinet.Storage.Core
{
    class SpecificationEvaluator<TEntity> where TEntity : BaseEntityDto
    {
        public static IQueryable<TEntity> GetQuery(IQueryable<TEntity> inputQuery,
            ISpecification<TEntity> spec)
        {
            var query = inputQuery;

            query = SpecificationEvaluatorCriteria<TEntity>.GetQuery(query, spec);

            query = spec.Includes.Aggregate(query, (current, include) => current.Include(include));

            if (spec.OrderBy != null)
            {
                query = query.OrderBy(spec.OrderBy);
            }

            if (spec.OrderByDescending != null)
            {
                query = query.OrderByDescending(spec.OrderByDescending);
            }

            if (spec.IsPagingEnabled)
            {
                query = query.Skip(spec.Skip).Take(spec.Take);
            }

            return query;
        }
    }
}
