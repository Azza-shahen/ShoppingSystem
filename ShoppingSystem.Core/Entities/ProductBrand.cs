namespace ShoppingSystem.Core.Entities;
public class ProductBrand : BaseModel
{
    public string Name { get; set; } = null!;
    //public  required string Name { get; set; } 


    //public ICollection<Product> Products { get; set; } = new HashSet<Product>(); // one-to-many
}

