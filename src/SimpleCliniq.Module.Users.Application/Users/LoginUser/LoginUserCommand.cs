using Simple.Common.Application.Messaging;

namespace SimpleCliniq.Module.Users.Application.Users.LoginUser;

public sealed record LoginUserCommand(string Email, string Password)
    : ICommand<Guid>;
