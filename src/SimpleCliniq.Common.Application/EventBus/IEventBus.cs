using Simple.Common.Application.EventBus;
namespace Simple.Common.Application.EventBus;

public interface IEventBus
{
    Task PublishAsync<T>(T integrationEvent, CancellationToken cancellationToken = default)
        where T : IIntegrationEvent;
}
