namespace Chefia.App.Dtos.Result;

public class Result
{
    protected Result(bool isSuccess, string? message, ErrorCode? errorCode)
    {
        if (isSuccess && errorCode is not null)
        {
            throw new ArgumentException("A successful result cannot contain an error code.");
        }

        if (!isSuccess && string.IsNullOrWhiteSpace(message))
        {
            throw new ArgumentException("A failure result must contain a message.");
        }

        if (!isSuccess && errorCode is null)
        {
            throw new ArgumentException("A failure result must contain an error code.");
        }

        IsSuccess = isSuccess;
        Message = message;
        ErrorCode = errorCode;
    }

    public bool IsSuccess { get; }

    public bool IsFailure => !IsSuccess;

    public string? Message { get; }

    public string? Error => IsFailure ? Message : null;

    public ErrorCode? ErrorCode { get; }

    public static Result Success(string? message = null)
    {
        return new Result(true, message, null);
    }

    public static Result Failure(string error, ErrorCode errorCode)
    {
        return new Result(false, error, errorCode);
    }
}

public class Result<T> : Result
{
    private Result(T? value, bool isSuccess, string? message, ErrorCode? errorCode)
        : base(isSuccess, message, errorCode)
    {
        Value = value;
    }

    public T? Value { get; }

    public static Result<T> Success(T value, string? message = null)
    {
        return new Result<T>(value, true, message, null);
    }

    public new static Result<T> Failure(string error, ErrorCode errorCode)
    {
        return new Result<T>(default, false, error, errorCode);
    }
}
