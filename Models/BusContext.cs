using Microsoft.EntityFrameworkCore;

namespace BusPassManagementSystem.Models
{
    public class BusContext : DbContext
    {
        public BusContext()
        {
        }
        public BusContext(DbContextOptions options):base(options)
        {

        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            IConfigurationRoot configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            optionsBuilder.UseSqlServer(configuration.GetConnectionString("Connect"));
        }
        public DbSet<userdetails>  userdetails{ get; set; }
        public DbSet<Addbus> addbus { get; set; }
        public DbSet<passtype> Passtypes { get; set; }
        public DbSet<ApplyPass> ApplyPasses { get; set; }
    }
}


