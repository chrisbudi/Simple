using MediatR;
using SimpleCliniq.Common.Application.Authorization;
using SimpleCliniq.Common.Domain;
using SimpleCliniq.Module.Users.Application.Users.GetUserPermissions;

namespace SimpleCliniq.Module.Users.Infrastructure.Authorization;

internal sealed class PermissionService(ISender sender) : IPermissionService
{
    public async Task<Result<PermissionsResponse>> GetUserPermissionsAsync(string identityId)
    {
        return await sender.Send(new GetUserPermissionsQuery(identityId));
    }
}
