using System;
using System.Net;
using System.Text.Json;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

using Skinet.WebApi.Errors;

namespace Skinet.WebApi.Middleware
{
    public class ExceptionMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<ExceptionMiddleware> _logger;
        private readonly IHostEnvironment _env;
        private readonly IApiStatusMessageDictionary _messageDictionary;

        public ExceptionMiddleware(RequestDelegate next,
                                   ILogger<ExceptionMiddleware> logger,
                                   IHostEnvironment env,
                                   IApiStatusMessageDictionary messageDictionary)
        {
            _next = next;
            _logger = logger;
            _env = env;
            _messageDictionary = messageDictionary;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                context.Response.ContentType = "application/json";
                context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                var statusCode = (ApiStatusCode)context.Response.StatusCode;

                var response = _env.IsDevelopment()
                    ? new ApiException(statusCode, _messageDictionary, ex.Message, ex.StackTrace.ToString())
                    : new ApiException(statusCode, _messageDictionary);

                var options = new JsonSerializerOptions
                {
                    PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
                    IgnoreNullValues = true,
                    WriteIndented = true
                };

                var json = JsonSerializer.Serialize(new ApiExceptionDtoToJsonSerialize(response), options);

                await context.Response.WriteAsync(json);
            }
        }
    }
}
