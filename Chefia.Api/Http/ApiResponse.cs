namespace Chefia.Api.Http;

public class ApiResponse<T>
{
    public int StatusCode { get; set; }
    public string Message { get; set; }
    public T? Data { get; set; }
    public bool Success { get; set; }

    public ApiResponse(int statusCode, string message, T? data = default, bool success = true)
    {
        StatusCode = statusCode;
        Message = message;
        Data = data;
        Success = success;
    }
}
