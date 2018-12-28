using Microsoft.EntityFrameworkCore;
using Rasot.Core.Domain;
using Rasot.Data.Mappings.Contents;
using Rasot.Data.Mappings.Customers;

namespace Rasot.Data
{
    public class RasotDbContext:DbContext,IRasotDbContext
    {
        public RasotDbContext(DbContextOptions<RasotDbContext> options):base(options)
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySQL("server=localhost;port=3306; database=rasotdb; uid=root; password=001453");
            base.OnConfiguring(optionsBuilder);
        }

        public new  DbSet<TEntity> Set<TEntity>() where TEntity:BaseEntity
        {
            return base.Set<TEntity>();
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new CustomerMap());
            modelBuilder.ApplyConfiguration(new PostMap());

            base.OnModelCreating(modelBuilder);
        }
    }
}
