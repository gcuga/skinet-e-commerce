using System.Collections.Generic;
using System.Threading.Tasks;

using AutoMapper;

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

using Skinet.Core;
using Skinet.Storage.Core.Interfaces;
using Skinet.WebApi.Dtos;
using Skinet.WebApi.Errors;

namespace Skinet.WebApi.Controllers
{
    public class TypesController : BaseApiController
    {
        private readonly IProductStorage _productStorage;
        private readonly IMapper _mapper;

        public TypesController(IProductStorage productStorage,
                               IMapper mapper,
                               IApiStatusMessageDictionary statusMessageDictionary)
            : base(statusMessageDictionary)
        {
            _productStorage = productStorage;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IReadOnlyList<ProductTypeToReturnDto>>> Get()
        {
            var productTypes = await _productStorage.GetProductTypesAsync();

            return Ok(_mapper
                .Map<IReadOnlyList<ProductType>, IReadOnlyList<ProductTypeToReturnDto>>(productTypes));
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status404NotFound)]
        public async Task<ActionResult<ProductTypeToReturnDto>> Get(int id)
        {
            ProductType productType = await _productStorage.GetProductTypeAsync(id);

            if (productType != null)
            {
                var productTypeToReturnDto =
                    _mapper.Map<ProductType, ProductTypeToReturnDto>(productType);

                return Ok(productTypeToReturnDto);
            }

            return NotFound(new ApiResponse(ApiStatusCode.NotFound, _statusMessageDictionary));
        }
    }
}
