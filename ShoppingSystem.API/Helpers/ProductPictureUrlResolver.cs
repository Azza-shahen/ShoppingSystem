using AutoMapper;

namespace ShoppingSystem.API.Helpers
{
    // This class is a custom value resolver used by AutoMapper
    // It is responsible for constructing the full image URL
    // when mapping from Product entity to ProductDto.
    public sealed class ProductPictureUrlResolver(IConfiguration configuration) : IValueResolver<Product, ProductDto, string>
    {     // IConfiguration is injected to read values from appsettings.json"ApiBaseUrl".
          //sealed:There's no need for anyone to inherit from this class.it is for mapping only.

        // This method is automatically called by AutoMapper during mapping.
        // It calculates the final value for the PictureUrl property.
        public string Resolve(
                Product source,
                ProductDto destination,
                string destMember,
                ResolutionContext context)
        {

            if (string.IsNullOrWhiteSpace(source.PictureUrl))
                return string.Empty;

            // Combine the ApiBaseUrl with the stored relative path to generate a complete absolute URL
            return $"{configuration["ApiBaseUrl"]}/{source.PictureUrl}";
        }
    }


}
