using SimpleCliniq.Module.Users.Domain.Users;

namespace SimpleCliniq.Module.Users.Domain.Users;

public sealed class Role
{
    public static readonly Role Administrator = new("Administrator");
    public static readonly Role Member = new("Member");

    private Role(string name)
    {
        Name = name;
    }

    private Role()
    {
    }

    public string Name { get; private set; }
}
