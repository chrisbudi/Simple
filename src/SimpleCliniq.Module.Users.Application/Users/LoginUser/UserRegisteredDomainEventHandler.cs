using MediatR;
using SimpleCliniq.Module.Users.Application.Users.GetUser;
using SimpleCliniq.Module.Users.Domain.Users;
using SimpleCliniq.Module.Users.IntegrationEvents;
using Simple.Common.Application.EventBus;
using Simple.Common.Application.Exceptions;
using Simple.Common.Application.Messaging;
using Simple.Common.Domain;

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
            throw new SimpleException(nameof(GetUserQuery), result.Error);
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
