using SimpleCliniq.Common.Application.EventBus;
namespace SimpleCliniq.Common.Application.EventBus;

public interface IEventBus
{
    Task PublishAsync<T>(T integrationEvent, CancellationToken cancellationToken = default)
        where T : IIntegrationEvent;
}
