using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Skinet.WebApi.Errors
{
    public class ApiValidationErrorResponseDto
    {
        public int Status { get; }
        public string Message { get; }
        public IEnumerable<string> Errors { get; }

        public ApiValidationErrorResponseDto(ApiValidationErrorResponse validationErrorResponse)
        {
            Status = (int)validationErrorResponse.StatusCode;
            Message = validationErrorResponse.Message;
            Errors = validationErrorResponse.Errors;
        }
    }
}
