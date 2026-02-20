using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ShoppingSystem.API.Mapping;
using System.Reflection;

namespace ShoppingSystem.API.Extensions;
public static class ConfigureServicesExtensions
{
    public static IServiceCollection AddWebServices(this IServiceCollection services,
           WebApplicationBuilder builder)
    {
        services.AddDbContext<ShoppingSystemDbContext>(options =>
        {
            options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
        });

        /*
        services.AddScoped<IGenericRepository<Product>,IGenericRepository<Product>>();
        services.AddScoped<IGenericRepository<ProductBrand>,IGenericRepository<ProductBrand>>();
        services.AddScoped<IGenericRepository<ProductCategory>,IGenericRepository<ProductCategory>>();
         */
        //OR
        services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));

        //services.AddAutoMapper(typeof(MappingProfile));//Registers only from the given type and nearby classes. Limited scope.
        services.AddAutoMapper(Assembly.GetAssembly(typeof(MappingProfile)));//Scans the entire assembly for all classes inheriting from Profile. Broader and safer.

        // Configure how ASP.NET Core handles automatic model validation errors
        services.Configure<ApiBehaviorOptions>(options =>
        {
            // Override the default response returned when ModelState is invalid
            options.InvalidModelStateResponseFactory = context =>
            {
                // Extract validation errors from ModelState
                var errors = context.ModelState
                    .Where(x => x.Value?.Errors.Count > 0)  // Filter entries that actually contain errors
                    .SelectMany(x => x.Value!.Errors)
                    .Select(x => x.ErrorMessage)// Select only the error message text
                    .ToList();

                // Create a custom validation response object
                var response = new ApiValidationErrorResponse
                {
                    Errors = errors
                };

                return new BadRequestObjectResult(response);
            };
           
        });
        return services;
    }
    
}

