using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text.Json;
using System.Threading.Tasks;
using DotnetFoundation.Presentation.Errors;

namespace DotnetFoundation.Presentation.Middleware
{
    public class ExceptionMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<ExceptionMiddleware> _logger;
        private readonly IHostEnvironment _hostEnvironment;

        public ExceptionMiddleware(
            RequestDelegate next,
            ILogger<ExceptionMiddleware> logger,
            IHostEnvironment hostEnvironment)
        {
            _next = next;
            _logger = logger;
            _hostEnvironment = hostEnvironment;
        }
        public async Task InvokeAsync(HttpContext httpContext)
        {
            try
            {
                await _next(httpContext);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                httpContext.Response.ContentType = "application/json";
                httpContext.Response.StatusCode = (int)HttpStatusCode.InternalServerError;

                APIException response = _hostEnvironment.IsDevelopment() ?
                    new APIException((int)HttpStatusCode.InternalServerError, ex.Message, ex.StackTrace.ToString())
                    : new APIException((int)HttpStatusCode.InternalServerError);

                JsonSerializerOptions options = new JsonSerializerOptions { PropertyNamingPolicy = JsonNamingPolicy.CamelCase };
                string json = JsonSerializer.Serialize(response, options);

                await httpContext.Response.WriteAsync(json);
            }
        }
    }
}