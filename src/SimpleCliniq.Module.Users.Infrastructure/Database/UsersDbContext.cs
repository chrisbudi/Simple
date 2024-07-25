using Microsoft.EntityFrameworkCore;
using SimpleCliniq.Common.Infrastructure.Inbox;
using SimpleCliniq.Common.Infrastructure.Outbox;
using SimpleCliniq.Module.Users.Application.Abstractions.Data;
using SimpleCliniq.Module.Users.Domain.Users;
using SimpleCliniq.Module.Users.Infrastructure.Users;

namespace SimpleCliniq.Module.Users.Infrastructure.Database;

public sealed class UsersDbContext(DbContextOptions<UsersDbContext> options) : DbContext(options), IUnitOfWork
{
    internal DbSet<User> Users { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.HasDefaultSchema(Schemas.Users);

        modelBuilder.ApplyConfiguration(new OutboxMessageConfiguration());
        modelBuilder.ApplyConfiguration(new OutboxMessageConsumerConfiguration());
        modelBuilder.ApplyConfiguration(new InboxMessageConfiguration());
        modelBuilder.ApplyConfiguration(new InboxMessageConsumerConfiguration());
        modelBuilder.ApplyConfiguration(new UserConfiguration());
        modelBuilder.ApplyConfiguration(new RoleConfiguration());
        modelBuilder.ApplyConfiguration(new PermissionConfiguration());
    }
}
