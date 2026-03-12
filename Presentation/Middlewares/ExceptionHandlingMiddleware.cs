using Application.Shared.Exceptions;
using Domain.Exceptions;
using Microsoft.Extensions.Logging;

namespace Presentation.Middlewares
{
    public class ExceptionHandlingMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<ExceptionHandlingMiddleware> _logger;

        public ExceptionHandlingMiddleware(RequestDelegate next, ILogger<ExceptionHandlingMiddleware> logger)
        {
            _next = next;
            _logger = logger;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (ValidationException ex)
            {
                var response = context.Response;
                response.ContentType = "application/json";
                response.StatusCode = StatusCodes.Status400BadRequest;
                await response.WriteAsJsonAsync(new
                {
                    Error = ex.Message
                });
            }
            catch (EntityNotFoundException ex)
            {
                var response = context.Response;
                response.ContentType = "application/json";
                response.StatusCode = StatusCodes.Status404NotFound;
                await response.WriteAsJsonAsync(new
                {
                    Error = ex.Message
                });
            }
            catch (NotImplementedException)
            {
                var response = context.Response;
                response.ContentType = "application/json";
                response.StatusCode = StatusCodes.Status501NotImplemented;
                await response.WriteAsJsonAsync(new
                {
                    Error = "This functionality is not implemented yet."
                });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);

                var response = context.Response;
                response.ContentType = "application/json";
                response.StatusCode = StatusCodes.Status500InternalServerError;
                await response.WriteAsJsonAsync(new
                {
                    Error = "Internal server error."
                });
            }
        }
    }
}
