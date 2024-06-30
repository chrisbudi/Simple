using SimpleCliniq.Common.Domain;

namespace SimpleCliniq.Common.Application.Authorization;

public interface IPermissionService
{
    Task<Result<PermissionsResponse>> GetUserPermissionsAsync(string identityId);
}
