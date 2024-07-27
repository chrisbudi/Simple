using SimpleCliniq.Common.Domain;

namespace SimpleCliniq.Common.Application.Exceptions;

public sealed class SimpleException : Exception
{
    public SimpleException(string requestName, Error? error = default, Exception? innerException = default)
        : base("Application exception", innerException)
    {
        RequestName = requestName;
        Error = error;
    }

    public string RequestName { get; }

    public Error? Error { get; }
}
