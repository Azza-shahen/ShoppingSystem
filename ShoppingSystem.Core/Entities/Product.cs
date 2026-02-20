namespace ShoppingSystem.Core.Entities;
public class Product : BaseModel
{
    public string Name { get; set; } = null!;
    public string Description { get; set; } = null!;
    public string PictureUrl { get; set; } = null!;
    public decimal Price { get; set; }

    //Navigation Properties
    //One Brand has many Products.(one to Many Relation).
    public int BrandId { get; set; }//Foreign Key 
    public ProductBrand Brand { get; set; } = null!;
    public int CategoryId { get; set; }
    public ProductCategory Category { get; set; } = null!;
}

