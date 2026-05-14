using Chefia.App.Dtos.Result;
using Microsoft.AspNetCore.Mvc;
namespace Chefia.Api.Http;

public static class ControllerBaseExtensions
{
    public static ActionResult<ApiResponse<T>> ToApiResponse<T>(
        this ControllerBase controller,
        Result<T> result,
        int successStatusCode = StatusCodes.Status200OK)
    {
        if (result.IsSuccess)
        {
            var successResponse = new ApiResponse<T>(
                successStatusCode,
                result.Message ?? "Operação realizada com sucesso.",
                result.Value,
                true);

            return Success(controller, successStatusCode, successResponse);
        }

        var message = result.Message ?? "Ocorreu um erro inesperado.";

        return result.ErrorCode switch
        {
            ErrorCode.Unauthorized => controller.Unauthorized(Api<T>(StatusCodes.Status401Unauthorized, message)),
            ErrorCode.Forbidden => controller.StatusCode(StatusCodes.Status403Forbidden, Api<T>(StatusCodes.Status403Forbidden, message)),
            ErrorCode.Conflict => controller.Conflict(Api<T>(StatusCodes.Status409Conflict, message)),
            ErrorCode.UnprocessableEntity => controller.UnprocessableEntity(Api<T>(StatusCodes.Status422UnprocessableEntity, message)),
            ErrorCode.NotFound => controller.NotFound(Api<T>(StatusCodes.Status404NotFound, message)),
            ErrorCode.InternalServerError => controller.StatusCode(StatusCodes.Status500InternalServerError, Api<T>(StatusCodes.Status500InternalServerError, message)),
            _ => controller.BadRequest(Api<T>(StatusCodes.Status400BadRequest, message))
        };
    }

    public static ActionResult<ApiResponse<object>> ToApiResponse(
        this ControllerBase controller,
        Result result,
        int successStatusCode = StatusCodes.Status200OK)
    {
        if (result.IsSuccess)
        {
            var successResponse = new ApiResponse<object>(
                successStatusCode,
                result.Message ?? "Operação realizada com sucesso.",
                success: true);

            return Success(controller, successStatusCode, successResponse);
        }

        var message = result.Message ?? "Ocorreu um erro inesperado.";

        return result.ErrorCode switch
        {
            ErrorCode.Unauthorized => controller.Unauthorized(Api<object>(StatusCodes.Status401Unauthorized, message)),
            ErrorCode.Forbidden => controller.StatusCode(StatusCodes.Status403Forbidden, Api<object>(StatusCodes.Status403Forbidden, message)),
            ErrorCode.Conflict => controller.Conflict(Api<object>(StatusCodes.Status409Conflict, message)),
            ErrorCode.UnprocessableEntity => controller.UnprocessableEntity(Api<object>(StatusCodes.Status422UnprocessableEntity, message)),
            ErrorCode.NotFound => controller.NotFound(Api<object>(StatusCodes.Status404NotFound, message)),
            ErrorCode.InternalServerError => controller.StatusCode(StatusCodes.Status500InternalServerError, Api<object>(StatusCodes.Status500InternalServerError, message)),
            _ => controller.BadRequest(Api<object>(StatusCodes.Status400BadRequest, message))
        };
    }

    private static ActionResult<ApiResponse<T>> Success<T>(
        ControllerBase controller,
        int statusCode,
        ApiResponse<T> response)
    {
        return statusCode switch
        {
            StatusCodes.Status200OK => controller.Ok(response),
            StatusCodes.Status201Created => controller.StatusCode(StatusCodes.Status201Created, response),
            _ => controller.StatusCode(statusCode, response)
        };
    }

    private static ApiResponse<T> Api<T>(int statusCode, string message)
    {
        return new ApiResponse<T>(
            statusCode,
            message,
            data: default,
            success: false);
    }
}
