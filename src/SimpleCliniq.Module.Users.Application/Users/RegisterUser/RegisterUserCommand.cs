using SimpleCliniq.Common.Application.Messaging;

namespace SimpleCliniq.Module.Users.Application.Users.RegisterUser;

public sealed record RegisterUserCommand(string Email, string Password, string FirstName, string LastName)
    : ICommand<Guid>;
