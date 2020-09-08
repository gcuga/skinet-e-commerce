using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

using Microsoft.EntityFrameworkCore;

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
    }
}
