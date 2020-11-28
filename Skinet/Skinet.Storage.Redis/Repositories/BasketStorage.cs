using System;
using System.Threading.Tasks;

using Newtonsoft.Json;

using Skinet.Storage.Redis.Entities;
using Skinet.Storage.Redis.Interfaces;

using StackExchange.Redis;

namespace Skinet.Storage.Redis.Repositories
{
    public class BasketStorage : IBasketStorage
    {
        private readonly IDatabase _database;

        public BasketStorage(IConnectionMultiplexer redis)
        {
            _database = redis.GetDatabase();
        }

        public async Task<bool> DeleteBasketAsync(string basketId)
        {
            return await _database.KeyDeleteAsync(basketId);
        }

        public async Task<CustomerBasketDto> GetBasketAsync(string basketId)
        {
            var json = await _database.StringGetAsync(basketId);

            return json.IsNullOrEmpty ? null : JsonConvert.DeserializeObject<CustomerBasketDto>(json);
        }

        public async Task<CustomerBasketDto> UpdateBasketAsync(CustomerBasketDto basket)
        {
            var created = await _database.StringSetAsync(basket.Id,
                JsonConvert.SerializeObject(basket), TimeSpan.FromDays(30));

            if (!created) return null;

            return await GetBasketAsync(basket.Id);
        }
    }
}
