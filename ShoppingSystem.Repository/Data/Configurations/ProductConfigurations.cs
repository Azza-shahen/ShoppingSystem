namespace ShoppingSystem.Repository.Data.Configurations;
internal class ProductConfigurations : IEntityTypeConfiguration<Product>
{
    /*
         *  Inherit from IEntityTypeConfiguration<T> to:       
             -Configure entity mappings using Fluent API       
             -Keep code clean and separated                    
             -Apply advanced configurations outside DbContext  
             -Use ApplyConfiguration() to register them easily 
    */
    public void Configure(EntityTypeBuilder<Product> builder)
    {
        builder.Property(p => p.Name).IsRequired()
               .HasMaxLength(100);
        builder.Property(p => p.Description).IsRequired(); // required by default
        builder.Property(p => p.PictureUrl).IsRequired();
        builder.Property(p => p.Price).HasColumnType("decimal(18,2)");

        //Relations
        builder.HasOne(p => p.Brand)
               .WithMany().HasForeignKey(p => p.BrandId)
               .OnDelete(DeleteBehavior.Cascade);

        builder.HasOne(p => p.Category)
               .WithMany(C => C.Products)
               .HasForeignKey(p => p.CategoryId);
    }
}

