using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Agilite.UnitOfWork.Context;

internal class AgiliteDesignContext : AgiliteContext
{
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        IConfiguration configuration = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("C:\\Users\\H.DECUQ\\source\\repos\\HugoGit-Hub\\Agilite\\Agilite.Api\\appsettings.json")
            .Build();

        var connectionString = configuration.GetConnectionString("DefaultConnection");
        optionsBuilder.UseSqlServer(connectionString);
        base.OnConfiguring(optionsBuilder);
    }
}