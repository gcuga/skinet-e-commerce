using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Skinet.WebApi.Errors
{
    public class ApiExceptionDtoToJsonSerialize
    {
        public int Status { get; }
        public string Message { get; }
        public string Details { get; }

        public ApiExceptionDtoToJsonSerialize(ApiException apiException)
        {
            Status = (int)apiException.StatusCode;
            Message = apiException.Message;
            Details = apiException.Details;
        }
    }
}
