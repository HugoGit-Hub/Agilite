using Microsoft.EntityFrameworkCore;

namespace Agilite.UnitOfWork;

internal class AgiliteDesignContext : AgiliteContext
{
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer();
        base.OnConfiguring(optionsBuilder);
    }
}