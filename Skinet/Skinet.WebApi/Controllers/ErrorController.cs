using Microsoft.AspNetCore.Mvc;

using Skinet.WebApi.Errors;

namespace Skinet.WebApi.Controllers
{
    [Route("errors/{code}")]
    [ApiExplorerSettings(IgnoreApi = true)]
    public class ErrorController : BaseApiController
    {
        public ErrorController(IApiStatusMessageDictionary statusMessageDictionary) 
            : base(statusMessageDictionary)
        {
        }

        public IActionResult Error(int code)
        {
            ApiStatusCode apiStatusCode = (ApiStatusCode)code;
            return new ObjectResult(new ApiResponse(apiStatusCode, _statusMessageDictionary));
        }
    }
}
