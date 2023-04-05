using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace EFCoreAPI.Models.DbContexts
{
    public class AppDbContextFactory : IDesignTimeDbContextFactory<AppDbContext>
    {
        public AppDbContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<AppDbContext>();
            optionsBuilder.UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=EFCoreAPIMentorship;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Multi Subnet Failover=False");
            return new AppDbContext(optionsBuilder.Options);
        }
    }
}
