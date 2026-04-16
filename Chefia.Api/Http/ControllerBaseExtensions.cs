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
        if (result.IsFailure)
        {
            var errorStatusCode = (int)(result.ErrorCode ?? ErrorCode.BadRequest);
            var errorResponse = new ApiResponse<T>(
                errorStatusCode,
                result.Message ?? "Não foi possível processar a requisição.",
                success: false);

            return controller.StatusCode(errorStatusCode, errorResponse);
        }

        var successResponse = new ApiResponse<T>(
            successStatusCode,
            result.Message ?? "Operação realizada com sucesso.",
            result.Value,
            true);

        return controller.StatusCode(successStatusCode, successResponse);
    }

    public static ActionResult<ApiResponse<object>> ToApiResponse(
        this ControllerBase controller,
        Result result,
        int successStatusCode = StatusCodes.Status200OK)
    {
        if (result.IsFailure)
        {
            var errorStatusCode = (int)(result.ErrorCode ?? ErrorCode.BadRequest);
            var errorResponse = new ApiResponse<object>(
                errorStatusCode,
                result.Message ?? "Não foi possível processar a requisição.",
                success: false);

            return controller.StatusCode(errorStatusCode, errorResponse);
        }

        var successResponse = new ApiResponse<object>(
            successStatusCode,
            result.Message ?? "Operação realizada com sucesso.",
            success: true);

        return controller.StatusCode(successStatusCode, successResponse);
    }
}