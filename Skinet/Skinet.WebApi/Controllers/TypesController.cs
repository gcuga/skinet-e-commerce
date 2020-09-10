using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using AutoMapper;

using Microsoft.AspNetCore.Mvc;

using Skinet.Core;
using Skinet.WebApi.Dtos;

namespace Skinet.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TypesController : ControllerBase
    {
        private readonly IProductStorage _productStorage;
        private readonly IMapper _mapper;

        public TypesController(IProductStorage productStorage, IMapper mapper)
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
        public async Task<ActionResult<ProductTypeToReturnDto>> Get(int id)
        {
            ProductType productType = await _productStorage.GetProductTypeAsync(id);

            if (productType != null)
            {
                var productTypeToReturnDto =
                    _mapper.Map<ProductType, ProductTypeToReturnDto>(productType);

                return Ok(productTypeToReturnDto);
            }

            return NotFound();
        }
    }
}
