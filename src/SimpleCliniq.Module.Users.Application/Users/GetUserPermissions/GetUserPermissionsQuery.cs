using Simple.Common.Application.Authorization;
using Simple.Common.Application.Messaging;

namespace SimpleCliniq.Module.Users.Application.Users.GetUserPermissions;

public sealed record GetUserPermissionsQuery(string IdentityId) : IQuery<PermissionsResponse>;
