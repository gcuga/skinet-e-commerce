using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Microsoft.EntityFrameworkCore;

using Skinet.Storage.Core.Interfaces;
using Skinet.Storage.Core.Specifications;

namespace Skinet.Storage.Core
{
    public class GenericStorage<T, C> : IGenericStorage<T, C>
        where T : BaseEntityDto
        where C : DbContext
    {
        public C _context;

        public GenericStorage(C context)
        {
            _context = context;
        }

        public async Task<T> GetByIdAsync(int id)
        {
            return await _context.Set<T>().FindAsync(id);
        }

        public async Task<IReadOnlyList<T>> ListAllAsync()
        {
            return await _context.Set<T>().ToListAsync();
        }

        public async Task<T> GetEntityWithSpec(ISpecification<T> spec)
        {
            return await ApplySpecification(spec).FirstOrDefaultAsync();
        }

        public async Task<IReadOnlyList<T>> ListAsync(ISpecification<T> spec)
        {
            return await ApplySpecification(spec).ToListAsync();
        }

        public async Task<int> CountAsync(ISpecification<T> spec)
        {
            return await ApplySpecificationCriteriaOnly(spec).CountAsync();
        }

        private IQueryable<T> ApplySpecification(ISpecification<T> spec)
        {
            return SpecificationEvaluator<T>.GetQuery(_context.Set<T>().AsQueryable(), spec);
        }

        private IQueryable<T> ApplySpecificationCriteriaOnly(ISpecification<T> spec)
        {
            return SpecificationEvaluatorCriteria<T>.GetQuery(_context.Set<T>().AsQueryable(), spec);
        }
    }
}
