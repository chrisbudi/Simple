using MediatR;
using SimpleCliniq.Common.Application.EventBus;
using SimpleCliniq.Common.Application.Exceptions;
using SimpleCliniq.Common.Application.Messaging;
using SimpleCliniq.Common.Domain;
using SimpleCliniq.Module.Users.Application.Users.GetUser;
using SimpleCliniq.Module.Users.Domain.Users;
using SimpleCliniq.Module.Users.IntegrationEvents;

namespace SimpleCliniq.Module.Users.Application.Users.RegisterUser;

internal sealed class UserRegisteredDomainEventHandler(ISender sender, IEventBus bus)
    : DomainEventHandler<UserRegisteredDomainEvent>
{
    public override async Task Handle(
        UserRegisteredDomainEvent domainEvent,
        CancellationToken cancellationToken = default)
    {
        Result<UserResponse> result = await sender.Send(
            new GetUserQuery(domainEvent.UserId),
            cancellationToken);

        if (result.IsFailure)
        {
            throw new EventlyException(nameof(GetUserQuery), result.Error);
        }

        await bus.PublishAsync(
            new UserRegisteredIntegrationEvent(
                domainEvent.Id,
                domainEvent.OccurredOnUtc,
                result.Value.Id,
                result.Value.Email,
                result.Value.FirstName,
                result.Value.LastName),
            cancellationToken);
    }
}
