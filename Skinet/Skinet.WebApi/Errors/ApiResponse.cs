using System;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;

using Microsoft.AspNetCore.Mvc.Infrastructure;

namespace Skinet.WebApi.Errors
{
    public class ApiResponse
    {
        [JsonPropertyName("status")]
        public  ApiStatusCode StatusCode { get; }
        public string Message { get; }

        public ApiResponse(ApiStatusCode statusCode, 
            IApiStatusMessageDictionary statusMessageDictionary, string message = null)
        {
            StatusCode = statusCode;
            Message = message ?? statusMessageDictionary.GetDefaultMessageForStatusCode(statusCode);
        }
    }
}
