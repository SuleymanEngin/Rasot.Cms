using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace Rasot.Data.Migrations
{
    public class RasotDbContextFactory : IDesignTimeDbContextFactory<RasotDbContext>
    {
        public RasotDbContext CreateDbContext(string[] args)
        {

            var optionsBuilder = new DbContextOptionsBuilder<RasotDbContext>();
            optionsBuilder.UseMySQL("server=mysql;port=3306; database=rasotdb; uid=root; password=001453");
            return new RasotDbContext(optionsBuilder.Options);
        }
    }
}
