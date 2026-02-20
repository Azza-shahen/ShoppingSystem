namespace ShoppingSystem.API.Extensions
{
    public static class SwaggerServicesExtensions
    {
        public static IServiceCollection AddSwaggerServices(this IServiceCollection services)
        {
            //This is an internal service that helps Swagger identify all the endpoints in the project (specifically Minimal APIs or API Explorer).
            services.AddEndpointsApiExplorer();

            // Registers Swagger (OpenAPI) generator service (used to generate Swagger docs for your API)
            services.AddSwaggerGen();

            return services;
        }

        public static WebApplication UseSwaggerMiddlewares(this WebApplication app) 
            {
            app.UseSwagger();
            app.UseSwaggerUI();
            return app;
            }
    }
}
