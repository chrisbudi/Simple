using SimpleCliniq.Common.Application.Authorization;
using SimpleCliniq.Common.Application.Messaging;

namespace SimpleCliniq.Module.Users.Application.Users.GetUserPermissions;

public sealed record GetUserPermissionsQuery(string IdentityId) : IQuery<PermissionsResponse>;
