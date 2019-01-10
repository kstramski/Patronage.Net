using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using Application.Exceptions;
using Application.Interfaces;

namespace Infrastructure.Middlewares
{
    public class ExceptionHandlerMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger _logger;

        public ExceptionHandlerMiddleware(RequestDelegate next, ILogger logger)
        {
            _next = next ?? throw new ArgumentNullException(nameof(next));
            _logger = logger;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (HttpStatusCodeException e)
            {
                if (context.Response.HasStarted)
                {
                    throw;
                }
                
                await HandleExceptionAsync(_logger, context, e.Message, (int)e.StatusCode);
            }
            catch (Exception e)
            {
                await HandleExceptionAsync(_logger, context, e.Message);
            }
        }

        private static Task HandleExceptionAsync(ILogger logger, HttpContext context, string message, int statusCode = 500)
        {
            logger.LogError(DateTime.Now + " | StatusCode: " + statusCode + " Message: " + message);

            message = JsonConvert.SerializeObject(new { Error = message });
            
            context.Response.StatusCode = statusCode;
            context.Response.ContentType = "application/json";
            return context.Response.WriteAsync(message);
        }
    }

    
}
