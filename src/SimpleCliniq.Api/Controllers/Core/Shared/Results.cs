namespace SimpleCliniqApi.Controllers.Core.Shared;

public class Result
{
    public bool Error { get; }
    public string Message { get; }
    public object Data { get; }

    private Result(bool error, string message, object data)
    {
        if (error && string.IsNullOrEmpty(message))
        {
            throw new InvalidOperationException("Error result must have a message");
        }

        Error = error;
        Message = message ?? "successfully"; // Use default message if null
        Data = data;
    }

    public static Result Success(object data)
    {
        return new Result(false, "successfully", data);
    }

    public static Result Failure(string message, object data = null)
    {
        return new Result(true, message, data);
    }

    public static Result From<TValue>(TValue? value)
    {
        return value is null ? Failure("Null value") : Success(value);
    }
}