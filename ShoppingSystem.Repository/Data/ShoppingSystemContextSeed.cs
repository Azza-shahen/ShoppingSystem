using System.Text.Json;

namespace ShoppingSystem.Repository.Data;
public static class ShoppingSystemContextSeed
{
    public async static Task SeedAsync(ShoppingSystemDbContext _dbContext)
    {

        if (_dbContext.Brands.Count() == 0)
        {
            var brandsData = File.ReadAllText("../ShoppingSystem.Repository/Data/DataSeed/brands.json");
            var brands = JsonSerializer.Deserialize<List<ProductBrand>>(brandsData);

            if (brands?.Count() > 0)//brands is not null && brands.Count() > 0
            {
                foreach (var brand in brands)
                {
                    _dbContext.Set<ProductBrand>().Add(brand);
                }
                await _dbContext.SaveChangesAsync();
            }
        }

        if (_dbContext.Categories.Count() == 0)
        {
            var categoriesData = File.ReadAllText("../ShoppingSystem.Repository/Data/DataSeed/categories.json");

            var categories = JsonSerializer.Deserialize<List<ProductCategory>>(categoriesData);

            if (categories?.Count() > 0)
            {
                foreach (var category in categories)
                {
                    await _dbContext.AddAsync(category);

                }
                await _dbContext.SaveChangesAsync();
            }
        }

        if (_dbContext.Products.Count() == 0)
        {
            var productsData = File.ReadAllText("../ShoppingSystem.Repository/Data/DataSeed/products.json");

            var products = JsonSerializer.Deserialize<List<Product>>(productsData);

            if (products?.Count() > 0)
            {
                foreach (var product in products)
                {
                    await _dbContext.AddAsync(product);

                }
                await _dbContext.SaveChangesAsync();
            }
        }
    }

}