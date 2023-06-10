using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Agilite.UnitOfWork;

internal class AgiliteDesignContext : AgiliteContext
{
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        IConfiguration configuration = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("C:\\Users\\hugod\\source\\repos\\Agilite\\Agilite.Api\\appsettings.Development.json")
            .Build();

        var connectionString = configuration.GetConnectionString("DefaultConnection");
        optionsBuilder.UseSqlServer(connectionString);
        base.OnConfiguring(optionsBuilder);
    }
}