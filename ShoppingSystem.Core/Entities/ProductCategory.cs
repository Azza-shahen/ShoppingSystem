namespace ShoppingSystem.Core.Entities;
public class ProductCategory : BaseModel
{
    public string Name { get; set; } = null!;

    //Navigation Properties
   // public ICollection<Product> Products { get; set; } = new HashSet<Product>();
    /*  
       * I used ICollection because 
          1- it's a flexible interface that works great
             with Entity Framework and represents a collection of items in a relationship.
          2-tracks changes(Add/Remove) easily

       * I used HashSet because
          1-it prevents duplicate items automatically(unlike List).
          2- It’s faster for lookup and removal
    */

}

