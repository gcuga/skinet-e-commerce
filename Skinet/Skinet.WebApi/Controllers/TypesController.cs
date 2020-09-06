using System.Collections.Generic;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Mvc;

using Skinet.Core;

namespace Skinet.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TypesController : ControllerBase
    {
        private readonly IProductStorage _productStorage;

        public TypesController(IProductStorage productStorage)
        {
            _productStorage = productStorage;
        }

        [HttpGet]
        public async Task<ActionResult<List<ProductType>>> Get()
        {
            return Ok(await _productStorage.GetProductTypesAsync());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ProductType>> Get(int id)
        {
            ProductType productType = await _productStorage.GetProductTypeAsync(id);

            if (productType != null)
            {
                return Ok(productType);
            }

            return NotFound();
        }
    }
}
