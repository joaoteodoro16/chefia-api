using Microsoft.AspNetCore.Diagnostics;

namespace Chefia.Api.Http;

public sealed class GlobalExceptionHandler : IExceptionHandler
{
    private readonly ILogger<GlobalExceptionHandler> _logger;

    public GlobalExceptionHandler(ILogger<GlobalExceptionHandler> logger)
    {
        _logger = logger;
    }

    public async ValueTask<bool> TryHandleAsync(HttpContext httpContext, Exception exception, CancellationToken cancellationToken)
    {
        _logger.LogError(
            exception,
            "Unhandled exception while processing {Method} {Path}",
            httpContext.Request.Method,
            httpContext.Request.Path);

        var statusCode = _GetStatusCodeForException(exception);

        var message = _GetMessageForException(exception);

        httpContext.Response.StatusCode = statusCode;
        httpContext.Response.ContentType = "application/json";

        var response = new ApiResponse<object>(
            statusCode,
            message,
            success: false);

        await httpContext.Response.WriteAsJsonAsync(response, cancellationToken);

        return true;
    }

    private int _GetStatusCodeForException(Exception exception)
    {
        return exception switch
        {
            UnauthorizedAccessException => StatusCodes.Status401Unauthorized,
            ArgumentException => StatusCodes.Status400BadRequest,
            KeyNotFoundException => StatusCodes.Status404NotFound,
            InvalidOperationException => StatusCodes.Status409Conflict,
            _ => StatusCodes.Status500InternalServerError
        };
    }

    private string _GetMessageForException(Exception exception)
    {
        return exception switch
        {
            UnauthorizedAccessException => exception.Message,
            ArgumentException => exception.Message,
            KeyNotFoundException => exception.Message,
            InvalidOperationException => exception.Message,
            _ => "Ocorreu um erro interno no servidor."
        };
    }
}