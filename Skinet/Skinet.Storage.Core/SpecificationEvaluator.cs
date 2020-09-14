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

            if (spec.Criteria != null)
            {
                query = query.Where(spec.Criteria);
            }

            query = spec.Includes.Aggregate(query, (current, include) => current.Include(include));

            return query;
        }
    }
}