using SimpleCliniq.Common.Application.Messaging;

namespace SimpleCliniq.Module.Users.Application.Users.UpdateUser;

public sealed record UpdateUserCommand(Guid UserId, string FirstName, string LastName) : ICommand;
