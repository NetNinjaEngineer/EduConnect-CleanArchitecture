using FluentValidation;
using System.Text.Json;

namespace EduConnect.API
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
            ErrorDetails errorDetails = default!;
            switch (ex)
            {
                case ValidationException validationException:
                    var errors = validationException.Errors.Select(x => x.ErrorMessage);
                    errorDetails = new(422, errors, "Validation errors occured !!!");
                    break;

                default:
                    break;
            }

            await context.Response.WriteAsync(errorDetails.ToString());
        }

        internal sealed class ErrorDetails(int statusCode, IEnumerable<string> errors, string? description)
        {
            public int StatusCode { get; set; } = statusCode;
            public IEnumerable<string> Errors { get; set; } = errors;
            public string? Description { get; set; } = description;

            public override string ToString() => JsonSerializer.Serialize(this);
        }
    }
}
