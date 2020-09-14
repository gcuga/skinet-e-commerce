using System.Collections.Generic;
using System.Threading.Tasks;

using AutoMapper;

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

using Skinet.Core;
using Skinet.WebApi.Dtos;
using Skinet.WebApi.Errors;

namespace Skinet.WebApi.Controllers
{
    public class BrandsController : BaseApiController
    {
        private readonly IProductStorage _productStorage;
        private readonly IMapper _mapper;

        public BrandsController(IProductStorage productStorage,
                                IMapper mapper,
                                IApiStatusMessageDictionary statusMessageDictionary)
            : base(statusMessageDictionary)
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
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status404NotFound)]
        public async Task<ActionResult<ProductBrandToReturnDto>> Get(int id)
        {
            ProductBrand productBrand = await _productStorage.GetProductBrandAsync(id);

            if (productBrand != null)
            {
                var productBrandToReturnDto =
                    _mapper.Map<ProductBrand, ProductBrandToReturnDto>(productBrand);

                return Ok(productBrandToReturnDto);
            }

            return NotFound(new ApiResponse(ApiStatusCode.NotFound, _statusMessageDictionary));
        }

    }
}
