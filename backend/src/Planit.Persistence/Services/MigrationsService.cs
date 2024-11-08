using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Planit.Application.Interfaces;

namespace Planit.Persistence.Services;
public class MigrationsService : IApplicationInitializer
{
    private readonly ApplicationDbContext _dbContext;
    private readonly ILogger<MigrationsService> logger;

    public MigrationsService(ApplicationDbContext dbContext, ILogger<MigrationsService> logger)
    {
        _dbContext = dbContext;
        this.logger = logger;
    }

    public async Task ExecuteAsync()
    {
        logger.LogInformation("Applying migrations");
        await _dbContext.Database.MigrateAsync();
        logger.LogInformation("Migrations applied");
    }
}
