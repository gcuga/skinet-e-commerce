using System.Collections.Generic;
using System.Threading.Tasks;

using Microsoft.EntityFrameworkCore;

namespace Skinet.Storage.Core
{
    public interface IGenericStorage<T, C>
        where T : BaseEntityDto
        where C : DbContext
    {
        Task<T> GetByIdAsync(int id);
        Task<IReadOnlyList<T>> ListAllAsync();
    }
}
