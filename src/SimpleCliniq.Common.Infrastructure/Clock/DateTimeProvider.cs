using SimpleCliniq.Common.Application.Clock;

namespace SimpleCliniq.Common.Infrastructure.Clock;

internal sealed class DateTimeProvider : IDateTimeProvider
{
    public DateTime UtcNow => DateTime.UtcNow;
}
