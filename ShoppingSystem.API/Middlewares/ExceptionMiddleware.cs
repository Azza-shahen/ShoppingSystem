using System.Net;
using System.Text.Json;

namespace ShoppingSystem.API.Middlewares;
// Custom middleware responsible for catching unhandled exceptions
// and returning a standardized JSON error response.
public class ExceptionMiddleware(RequestDelegate _next,// Delegate representing the next middleware in the pipeline
                                 ILogger<ExceptionMiddleware> _logger,
                                 IHostEnvironment _env)
{
    public async Task InvokeAsync(HttpContext context)//This method is called automatically for every HTTP request
    {
        try
        {
            //await _next(httpContext);// Pass control to the next middleware in the pipeline
            await _next.Invoke(context);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, ex.Message); //Development

            context.Response.ContentType = "application/json";//Set response content type to JSON
            context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;//500 

            var response = _env.IsDevelopment() ?
                new ApiExceptionResponse((int)HttpStatusCode.InternalServerError, ex.Message, ex.StackTrace)
                : new ApiExceptionResponse((int)HttpStatusCode.InternalServerError, "An unexpected error occurred. Please try again later.");

            // Configure JSON serialization to use camelCase naming
            var options = new JsonSerializerOptions() { PropertyNamingPolicy = JsonNamingPolicy.CamelCase };

            //var json = JsonSerializer.Serialize(response, options);//object to JSON

            await context.Response.WriteAsJsonAsync(response, options);

        }
    }
}

