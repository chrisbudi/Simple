using Simple.Common.Domain;

namespace SimpleCliniq.Module.Users.Application.Abstractions.Identity;

public interface IIdentityProviderService
{
    Task<Result<string>> RegisterUserAsync(UserModel user, CancellationToken cancellationToken = default);
    //Task<Result<string>> LoginUserAsync(UserLoginModel user, CancellationToken cancellationToken = default);
}
