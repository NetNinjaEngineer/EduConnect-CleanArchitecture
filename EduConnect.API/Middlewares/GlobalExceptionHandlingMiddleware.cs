using EduConnect.Application.Exceptions;
using FluentValidation;
using System.Net;
using System.Text.Json;

namespace EduConnect.API.Middlewares
{
    public class GlobalExceptionHandlingMiddleware
    {
        private readonly ILogger<GlobalExceptionHandlingMiddleware> _logger;
        private readonly RequestDelegate _requestDelegate;

        public GlobalExceptionHandlingMiddleware(ILogger<GlobalExceptionHandlingMiddleware> logger, RequestDelegate requestDelegate)
        {
            _logger = logger;
            _requestDelegate = requestDelegate;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _requestDelegate(context);
            }
            catch (Exception ex)
            {
                await HandleExceptionAsync(ex, context);
            }
        }

        private static async Task HandleExceptionAsync(Exception ex, HttpContext context)
        {
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
            ErrorDetails errorDetails = default!;
            switch (ex)
            {
                case ValidationException validationException:
                    context.Response.StatusCode = (int)HttpStatusCode.UnprocessableEntity;
                    var errors = validationException.Errors.Select(x => x.ErrorMessage);
                    errorDetails = new((int)HttpStatusCode.UnprocessableEntity, errors, "Validation errors occured !!!");
                    break;

                case NotFoundException:
                    context.Response.StatusCode = (int)HttpStatusCode.NotFound;
                    errorDetails = new((int)HttpStatusCode.NotFound, [ex.Message], "Resource not found.");
                    break;

                default:
                    errorDetails = new((int)HttpStatusCode.InternalServerError, [ex.Message]);
                    break;
            }

            await context.Response.WriteAsync(errorDetails.ToString());
        }

        internal sealed class ErrorDetails(int statusCode, IEnumerable<string> errors, string? description = null)
        {
            public int StatusCode { get; set; } = statusCode;
            public IEnumerable<string> Errors { get; set; } = errors;
            public string? Description { get; set; } = description;

            public override string ToString() => JsonSerializer.Serialize(this, new JsonSerializerOptions { PropertyNamingPolicy = JsonNamingPolicy.CamelCase });
        }
    }
}
