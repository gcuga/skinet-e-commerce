using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Skinet.WebApi.Errors
{
    public class ApiValidationErrorResponse : ApiResponse
    {
        public IEnumerable<string> Errors { get; set; }

        public ApiValidationErrorResponse(IApiStatusMessageDictionary statusMessageDictionary) 
            : base(ApiStatusCode.BadRequest, statusMessageDictionary)
        {

        }
    }
}
