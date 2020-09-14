using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Threading.Tasks;

namespace Skinet.WebApi.Errors
{
    public class ApiException : ApiResponse
    {
        public string Details { get; set; }

        public ApiException(ApiStatusCode statusCode,
                            IApiStatusMessageDictionary statusMessageDictionary,
                            string message = null,
                            string details = null) 
            : base(statusCode, statusMessageDictionary, message)
        {
            Details = details;
        }
    }
}
