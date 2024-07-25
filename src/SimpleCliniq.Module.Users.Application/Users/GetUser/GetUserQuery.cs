using SimpleCliniq.Common.Application.Messaging;

namespace SimpleCliniq.Module.Users.Application.Users.GetUser;

public sealed record GetUserQuery(Guid UserId) : IQuery<UserResponse>;
