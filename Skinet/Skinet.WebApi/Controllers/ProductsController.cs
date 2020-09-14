using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using AutoMapper;

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

using Skinet.Core;
using Skinet.WebApi.Dtos;
using Skinet.WebApi.Errors;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Skinet.WebApi.Controllers
{
    public class ProductsController : BaseApiController
    {
        private readonly IProductStorage _productStorage;
        private readonly IMapper _mapper;

        public ProductsController(IProductStorage productStorage,
                                  IMapper mapper,
                                  IApiStatusMessageDictionary statusMessageDictionary)
            : base(statusMessageDictionary)
        {
            _productStorage = productStorage;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IReadOnlyList<ProductToReturnDto>>> Get()
        {
            var products = await _productStorage.GetProductsAsync();

            return Ok(_mapper
                .Map<IReadOnlyList<Product>, IReadOnlyList<ProductToReturnDto>>(products));
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status404NotFound)]
        public async Task<ActionResult<ProductToReturnDto>> Get(int id)
        {
            Product product = await _productStorage.GetProductAsync(id);

            if (product != null) {
                var productToReturnDto = _mapper.Map<Product, ProductToReturnDto>(product);

                return Ok(productToReturnDto);
            }

            return NotFound(new ApiResponse(ApiStatusCode.NotFound, _statusMessageDictionary));
        }

        [HttpGet("brands")]
        public async Task<ActionResult<IReadOnlyList<ProductBrandToReturnDto>>> GetProductBrands()
        {
            var productBrands = await _productStorage.GetProductBrandsAsync();

            return Ok(_mapper
                .Map<IReadOnlyList<ProductBrand>, IReadOnlyList<ProductBrandToReturnDto>>(productBrands));
        }

        [HttpGet("types")]
        public async Task<ActionResult<IReadOnlyList<ProductTypeToReturnDto>>> GetProductTypes()
        {
            var productTypes = await _productStorage.GetProductTypesAsync();

            return Ok(_mapper
                .Map<IReadOnlyList<ProductType>, IReadOnlyList<ProductTypeToReturnDto>>(productTypes));
        }
    }
}
