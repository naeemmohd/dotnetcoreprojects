using Microsoft.EntityFrameworkCore;

namespace MyFirstWebAPIProject.Entities
{
    public class EFCoreDbContext : DbContext    
    {
        protected EFCoreDbContext() : base()
        {
        }
        protected EFCoreDbContext(DbContextOptions options) : base(options)
        {
        }

        //OnConfiguring() method is used to select and configure the data source
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                //use this to configure the context
                optionsBuilder.UseSqlite("Data source=mysqldb.db");
            }
        }

        //OnModelCreating() method is used to configure the model using ModelBuilder Fluent API
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //use this to configure the model
        }

        public DbSet<Student> Students { get; set; }
        public DbSet<Standard> Standards { get; set; }
    }
}