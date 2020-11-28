using System.Threading.Tasks;
using Skinet.Storage.Redis.Entities;

namespace Skinet.Storage.Redis.Interfaces
{
    public interface IBasketStorage
    {
        Task<CustomerBasketDto> GetBasketAsync(string basketId);
        Task<CustomerBasketDto> UpdateBasketAsync(CustomerBasketDto basket);
        Task<bool> DeleteBasketAsync(string basketId);
    }
}
