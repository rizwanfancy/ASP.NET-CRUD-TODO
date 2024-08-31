using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using web_api.Models;

namespace web_api.AppDataContext
{
    public class DatabaseContext : DbContext
    {
        // DbSettings field to store the connection string
        private readonly DbSettings _dbsettings;

        public DatabaseContext(IOptions<DbSettings> dbSettings)
        {
            _dbsettings = dbSettings.Value;
        }

        // DbSet property to represent the Todo table
        public DbSet<Todo> Todos { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Product> Products { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(_dbsettings.ConnectionString);

        }

        // Configuring the model for the Todo entity
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Todo>()
                .ToTable("TodoAPI")
                .HasKey(x => x.Id);
        }
    }
}
