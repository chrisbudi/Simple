﻿namespace Simple.Common.Domain;

public interface IDomainEvent
{
    Guid Id { get; }

    DateTime OccurredOnUtc { get; }
}
