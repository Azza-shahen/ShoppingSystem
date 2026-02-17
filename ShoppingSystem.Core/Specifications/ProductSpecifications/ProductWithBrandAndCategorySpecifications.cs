using ShoppingSystem.Core.Entities;

namespace ShoppingSystem.Core.Specifications.ProductSpecifications;

    public class ProductWithBrandAndCategorySpecifications : BaseSpecifications<Product>
    {

        // Initializes a new instance for retrieving all products with their brand and category included.
        public ProductWithBrandAndCategorySpecifications()
        : base() 
        {
            AddIncludes();
        }

        //Initializes a new instance for retrieving a single product by ID with its brand and category included.
        //"id":The ID of the product to retrieve.
        public ProductWithBrandAndCategorySpecifications(int id)
            : base(p => p.Id == id)
        {
            AddIncludes();
        }


        //Adds the necessary include expressions for Brand and Category navigation properties.
        private void AddIncludes()
        {
            Includes.Add(p => p.Brand);
            Includes.Add(p => p.Category);
        }
    }

