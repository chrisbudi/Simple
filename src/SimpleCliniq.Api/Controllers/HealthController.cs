using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SimpleCliniq.Module.Core.Infrastructure.Database;

namespace SimpleCliniqApi.Controllers;

[ApiController]
[Route("[controller]")]
public class HealthController : ControllerBase
{

    private readonly ILogger<HealthController> _logger;

    public IConfiguration _config;

    public HealthController(ILogger<HealthController> logger, IConfiguration config)
    {
        _logger = logger;
        _config = config;
    }

    [HttpGet(Name = "connectionstring")]
    public async Task<IActionResult> Get()
    {
        // check database connected
        var connectionString = _config.GetConnectionString("DefaultConnection");
        var options = new DbContextOptionsBuilder<SimpleCliniqCoreContext>()
            .UseNpgsql(connectionString)
            .Options;

        try
        {
            using (var context = new SimpleCliniqCoreContext(options))
            {
                await context.Database.OpenConnectionAsync();
                await context.Database.CloseConnectionAsync();
                return Ok("connected");
            }
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }

    }

    //[HttpGet(Name = "ConnectionString")]
    //public async Task<IActionResult> GetConnectionString()
    //{

    //}
}
