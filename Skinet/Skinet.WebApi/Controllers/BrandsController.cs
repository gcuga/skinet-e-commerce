using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using AutoMapper;

using Microsoft.AspNetCore.Mvc;

using Skinet.Core;
using Skinet.WebApi.Dtos;

namespace Skinet.WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BrandsController : ControllerBase
    {
        private readonly IProductStorage _productStorage;
        private readonly IMapper _mapper;

        public BrandsController(IProductStorage productStorage, IMapper mapper)
        {
            _productStorage = productStorage;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IReadOnlyList<ProductBrandToReturnDto>>> Get()
        {
            var productBrands = await _productStorage.GetProductBrandsAsync();

            return Ok(_mapper
                .Map<IReadOnlyList<ProductBrand>, IReadOnlyList<ProductBrandToReturnDto>>(productBrands));
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ProductBrandToReturnDto>> Get(int id)
        {
            ProductBrand productBrand = await _productStorage.GetProductBrandAsync(id);

            if (productBrand != null)
            {
                var productBrandToReturnDto =
                    _mapper.Map<ProductBrand, ProductBrandToReturnDto>(productBrand);

                return Ok(productBrandToReturnDto);
            }

            return NotFound();
        }

    }
}
