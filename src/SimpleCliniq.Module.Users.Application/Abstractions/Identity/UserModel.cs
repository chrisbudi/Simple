namespace SimpleCliniq.Module.Users.Application.Abstractions.Identity;

public sealed record UserModel(string Email, string Password, string FirstName, string LastName);
public sealed record UserLoginModel(string Email, string Password);
