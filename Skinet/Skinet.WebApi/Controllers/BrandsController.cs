using System.Collections.Generic;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Mvc;

using Skinet.Core;

namespace Skinet.WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BrandsController : ControllerBase
    {
        private readonly IProductStorage _productStorage;

        public BrandsController(IProductStorage productStorage)
        {
            _productStorage = productStorage;
        }

        [HttpGet]
        public async Task<ActionResult<List<ProductBrand>>> Get()
        {
            return Ok(await _productStorage.GetProductBrandsAsync());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ProductBrand>> Get(int id)
        {
            ProductBrand productBrand = await _productStorage.GetProductBrandAsync(id);

            if (productBrand != null)
            {
                return Ok(productBrand);
            }

            return NotFound();
        }

    }
}
