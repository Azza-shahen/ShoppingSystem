namespace ShoppingSystem.Repository.Data.Configurations;
internal class ProductCategoryConfigurations : IEntityTypeConfiguration<ProductCategory>
{
    public void Configure(EntityTypeBuilder<ProductCategory> builder)
    {
        builder.Property(p => p.Name).IsRequired();
    }
}

