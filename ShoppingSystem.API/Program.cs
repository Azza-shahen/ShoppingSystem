
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using ShoppingSystem.Repository.Data;
using System;

namespace ShoppingSystem.API
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            #region Configure Services
            // Add services to the container (Dependency Injection)

            // Register all required Web API services (e.g., controllers, model binding, routing)
            builder.Services.AddControllers();

            //This is an internal service that helps Swagger identify all the endpoints in the project (specifically Minimal APIs or API Explorer).
            builder.Services.AddEndpointsApiExplorer();

            // Registers Swagger (OpenAPI) generator service (used to generate Swagger docs for your API)
            builder.Services.AddSwaggerGen();
            builder.Services.AddDbContext<ShoppingSystemDbContext>(options =>
            {
                options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
            });

            #endregion

            var app = builder.Build();

            //Ask CLR For Creating Object From ShoppingSystemDbContext Explicitly
            using var scope = app.Services.CreateScope();
            var services = scope.ServiceProvider;
            var _dbcontext = services.GetRequiredService<ShoppingSystemDbContext>();

            var loggerFactory = services.GetService<ILoggerFactory>();// (used for logging errors)
            try
            {
                // Apply any pending migrations to the database when application Run
                await _dbcontext.Database.MigrateAsync();//Update-Database
            
            }
            catch (Exception ex)
            {
                /*
                 Console.WriteLine(ex); 
                 -it's limited to console output only
                 -it does not support log levels 
                (e.g., Error, Warning, Information), so all messages are treated the same.

                -ILogger supports log levels (Info, Warning, Error), and integrates with logging frameworks.
                -Create a logger specific to the Program class and log the exception details
                */
                if (loggerFactory != null)
                {
                    var log = loggerFactory.CreateLogger<Program>();
                    log.LogError(ex, "An error has occurred during database migration.");
                }

            }
            #region Configure Kestrel Middlewares
            // Set up the HTTP request processing pipeline (middleware)

            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();// Redirect all HTTP requests to HTTPS

            app.UseAuthorization();// Enable authorization middleware (e.g., [Authorize] attributes)
            /*
             * UseRouting + UseEndpoints = MapControllers
                   - UseRouting: Matches request to an endpoint.
                   - UseEndpoints: Execute the matched endpoint.
                   - MapControllers: This doesn't make any assumptions about routing and
                                     will rely on the user doing attribute routing 
                                     to get requests to the right place.
            */
            app.MapControllers();
            #endregion

          
            // Start the application (Starts listening for HTTP requests)
            app.Run();
        }
    }
}
