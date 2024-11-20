using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using tgworkshop.shared.config;

namespace tgworkshop.database;

public sealed class ContextFactory : IDesignTimeDbContextFactory<Context>
{
    public Context CreateDbContext(string[] args)
    {                
        return new Context(new DbContextOptionsBuilder<Context>().UseSqlServer(AppEnvironments.ConnectionString).Options);
    }
}
