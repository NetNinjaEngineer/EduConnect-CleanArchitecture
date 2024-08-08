using EduConnect.Application.Exceptions;
using EduConnect.Application.Resources;
using FluentValidation;
using Microsoft.Extensions.Localization;
using System.Net;
using System.Text.Json;

namespace EduConnect.API.Middlewares
{
    public class GlobalExceptionHandlingMiddleware
    {
        private readonly ILogger<GlobalExceptionHandlingMiddleware> _logger;
        private readonly RequestDelegate _requestDelegate;
        private readonly IStringLocalizer<SharedResources> _localizer;

        public GlobalExceptionHandlingMiddleware(
            ILogger<GlobalExceptionHandlingMiddleware> logger,
            RequestDelegate requestDelegate,
            IStringLocalizer<SharedResources> localizer)
        {
            _logger = logger;
            _requestDelegate = requestDelegate;
            _localizer = localizer;
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

        private async Task HandleExceptionAsync(Exception ex, HttpContext context)
        {
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
            ErrorDetails errorDetails = default!;
            switch (ex)
            {
                case ValidationException validationException:
                    context.Response.StatusCode = (int)HttpStatusCode.UnprocessableEntity;
                    var errors = validationException.Errors.Select(x => x.ErrorMessage);
                    errorDetails = new((int)HttpStatusCode.UnprocessableEntity, errors, _localizer[SharedResourcesKeys.ValidationErrors]);
                    break;

                case NotFoundException:
                    context.Response.StatusCode = (int)HttpStatusCode.NotFound;
                    errorDetails = new((int)HttpStatusCode.NotFound, [ex.Message], _localizer[SharedResourcesKeys.ResourceNotFound]);
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
