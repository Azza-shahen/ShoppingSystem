using System.Reflection;

namespace ShoppingSystem.Repository.Data
{
    public class ShoppingSystemDbContext : DbContext
    {
        /*
         * inheriting from DbContext
           - DbContext is the core class in EF Core that:
           - Connects your app to the database
           - define tables using DbSet<T>
           -Tracks changes (add, update, delete)
           -Saves data using SaveChanges()
           -Enables migrations to create/update the database
           -Handles relationships between entities
        */
        public ShoppingSystemDbContext(DbContextOptions<ShoppingSystemDbContext> options) : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            /* modelBuilder.ApplyConfiguration (new ProductCategoryConfigurations());
            modelBuilder.ApplyConfiguration (new ProductBrandConfigurations());
            modelBuilder.ApplyConfiguration (new ProductConfigurations());*/
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductBrand> Brands { get; set; }
        public DbSet<ProductCategory> Categories { get; set; }
    }
}
