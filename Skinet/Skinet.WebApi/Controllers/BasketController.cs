using System.Threading.Tasks;

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

using Skinet.Storage.Redis.Entities;
using Skinet.Storage.Redis.Interfaces;
using Skinet.WebApi.Errors;

namespace Skinet.WebApi.Controllers
{
    public class BasketController : BaseApiController
    {
        private readonly IBasketStorage _basketStorage;

        public BasketController(IBasketStorage basketStorage,
            IApiStatusMessageDictionary statusMessageDictionary) 
            : base(statusMessageDictionary)
        {
            _basketStorage = basketStorage;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<CustomerBasketDto>> GetBasketById(string id)
        {
            var basket = await _basketStorage.GetBasketAsync(id);

            return Ok(basket ?? new CustomerBasketDto(id));
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<CustomerBasketDto>> UpdateBasket(CustomerBasketDto basket)
        {
            var updatedBasket = await _basketStorage.UpdateBasketAsync(basket);

            return Ok(updatedBasket);
        }

        [HttpDelete]
        public async Task DeleteBasketAsync(string id)
        {
            await _basketStorage.DeleteBasketAsync(id);
        }
    }
}
