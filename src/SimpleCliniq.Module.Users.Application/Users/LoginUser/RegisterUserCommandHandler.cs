using Simple.Common.Application.Messaging;
using Simple.Common.Domain;
using SimpleCliniq.Module.Users.Application.Abstractions.Data;
using SimpleCliniq.Module.Users.Application.Abstractions.Identity;
using SimpleCliniq.Module.Users.Domain.Users;

namespace SimpleCliniq.Module.Users.Application.Users.LoginUser;

internal sealed class LoginUserCommandHandler(
    IIdentityProviderService identityProviderService,
    IUserRepository userRepository,
    IUnitOfWork unitOfWork)
    : ICommandHandler<LoginUserCommand, Guid>
{
    public async Task<Result<Guid>> Handle(LoginUserCommand request, CancellationToken cancellationToken)
    {
        Result<string> result = await identityProviderService.LoginUserAsync(
            new UserLoginModel(request.Email, request.Password),
            cancellationToken);

        if (result.IsFailure)
        {
            return Result.Failure<Guid>(result.Error);
        }

        //var user = User.Create(request.Email, request.FirstName, request.LastName, result.Value);

        //userRepository.Insert(user);

        //await unitOfWork.SaveChangesAsync(cancellationToken);

        //return user.Id;
    }
}
