using MediatR;
using SimpleCliniq.Module.Users.Application.Users.GetUserPermissions;
using Simple.Common.Application.Authorization;
using Simple.Common.Domain;

namespace SimpleCliniq.Module.Users.Infrastructure.Authorization;

internal sealed class PermissionService(ISender sender) : IPermissionService
{
    public async Task<Result<PermissionsResponse>> GetUserPermissionsAsync(string identityId)
    {
        return await sender.Send(new GetUserPermissionsQuery(identityId));
    }
}
