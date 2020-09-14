
using Microsoft.AspNetCore.Mvc;

using Skinet.WebApi.Errors;

namespace Skinet.WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BaseApiController : ControllerBase
    {
        protected readonly IApiStatusMessageDictionary _statusMessageDictionary;

        public BaseApiController(IApiStatusMessageDictionary statusMessageDictionary)
        {
            _statusMessageDictionary = statusMessageDictionary;
        }
    }
}
