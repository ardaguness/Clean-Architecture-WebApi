using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Features;
using Serilog;
using System;
using System.IO;
using System.Threading.Tasks;

namespace WebApi
{
    public class ErrorHandlingMiddleware
    {
        private readonly RequestDelegate next;

        public ErrorHandlingMiddleware(RequestDelegate next)
        {
            this.next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await next(context);
            }
            catch (Exception ex)
            {
                // Logs
                Log.Error("Error", ex, ex.Message);
                Log.Error("----------------------------");

                // Errors
                var response = context.Response;
                response.ContentType = "text/plain";
                response.StatusCode = StatusCodes.Status500InternalServerError;
                await response.WriteAsync($"Internal Server Error: {ex.Message}");
                await response.WriteAsync($"Error Message: {ex}");
            }
        }
    }
}
