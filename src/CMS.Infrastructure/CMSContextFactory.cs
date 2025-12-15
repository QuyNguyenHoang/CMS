using CMS.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace CMS.Core
{
    public class CMSContextFactory : IDesignTimeDbContextFactory<CMS_DBContext>
    {
        public CMS_DBContext CreateDbContext(string[] args)
        {
            var configuration = new ConfigurationBuilder()
                 .SetBasePath(Directory.GetCurrentDirectory())
                 .AddJsonFile("appsettings.json")
                 .Build();
            var builder = new DbContextOptionsBuilder<CMS_DBContext>();
            builder.UseSqlServer(configuration.GetConnectionString("DefaultConnection"));
            return new CMS_DBContext(builder.Options);
        }
    }
}
