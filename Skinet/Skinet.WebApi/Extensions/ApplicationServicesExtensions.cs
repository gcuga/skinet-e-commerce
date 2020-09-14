
using System.Linq;

using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;

using Skinet.Core;
using Skinet.Storage.SQLite.EF;
using Skinet.WebApi.Errors;

namespace Skinet.WebApi.Extensions
{
    public static class ApplicationServicesExtensions
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            services.AddSingleton<IApiStatusMessageDictionary, ApiStatusMessageDictionary>();
            services.AddScoped<IProductStorage, SQLiteProductStorage>();

            services.Configure<ApiBehaviorOptions>(options =>
            {
                options.InvalidModelStateResponseFactory = actionContext =>
                {
                    var errors = actionContext.ModelState
                        .Where(e => e.Value.Errors.Count > 0)
                        .SelectMany(x => x.Value.Errors)
                        .Select(x => x.ErrorMessage)
                        .ToArray();

                    var statusMessageDictionary = actionContext.HttpContext
                        .RequestServices
                        .GetService<IApiStatusMessageDictionary>();

                    var errorResponse = new ApiValidationErrorResponse(statusMessageDictionary)
                    {
                        Errors = errors
                    };

                    return new BadRequestObjectResult(new ApiValidationErrorResponseDto(errorResponse));
                };
            });

            return services;
        }
    }
}
