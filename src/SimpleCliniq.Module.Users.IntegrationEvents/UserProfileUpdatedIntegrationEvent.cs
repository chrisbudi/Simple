﻿using Simple.Common.Application.EventBus;

namespace SimpleCliniq.Module.Users.IntegrationEvents;

public sealed class UserProfileUpdatedIntegrationEvent : IntegrationEvent
{
    public UserProfileUpdatedIntegrationEvent(
        Guid id,
        DateTime occurredOnUtc,
        Guid userId,
        string firstName,
        string lastName)
        : base(id, occurredOnUtc)
    {
        UserId = userId;
        FirstName = firstName;
        LastName = lastName;
    }

    public Guid UserId { get; init; }

    public string FirstName { get; init; }

    public string LastName { get; init; }
}
