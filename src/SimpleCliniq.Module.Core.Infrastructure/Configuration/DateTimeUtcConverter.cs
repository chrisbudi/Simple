using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace SimpleCliniq.Module.Core.Infrastructure.Configuration
{
    public class DateTimeUtcConverter : ValueConverter<DateTime, DateTime>
    {
        public DateTimeUtcConverter()
            : base(
                dateTime => dateTime.Kind == DateTimeKind.Utc ? dateTime : dateTime.ToUniversalTime(),
                dateTime => DateTime.SpecifyKind(dateTime, DateTimeKind.Utc))
        { }
    }
}
