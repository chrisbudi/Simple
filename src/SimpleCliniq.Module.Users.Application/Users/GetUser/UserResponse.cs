﻿namespace SimpleCliniq.Module.Users.Application.Users.GetUser;

public sealed record UserResponse(Guid Id, string Email, string FirstName, string LastName);
