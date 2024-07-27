using Microsoft.EntityFrameworkCore;
using SimpleCliniq.Controllers;

namespace SimpleCliniq.Controllers;

public class MyDbContext : DbContext
{
    public MyDbContext(DbContextOptions<MyDbContext> options) : base(options) { }

    public DbSet<MyEntity> MyEntities { get; set; }
}

public class MyEntity
{
    public int Id { get; set; }
    public string Name { get; set; }
}
