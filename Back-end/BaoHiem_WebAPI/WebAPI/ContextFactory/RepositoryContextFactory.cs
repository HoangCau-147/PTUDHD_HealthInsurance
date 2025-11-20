using Entity.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Repository;

namespace WebAPI.ContextFactory
{
    public class RepositoryContextFactory : IDesignTimeDbContextFactory<InsuranceDBContext>
    {
        public InsuranceDBContext CreateDbContext(string[] args)
        {
            var configuration = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json")
            .Build();

            var builder = new DbContextOptionsBuilder<InsuranceDBContext>()
                .UseSqlServer(configuration.GetConnectionString("InsuranceConnectionString"),
                b => b.MigrationsAssembly("WebAPI"));
            return new InsuranceDBContext(builder.Options);
        }
    }
}
