namespace ShoppingSystem.API.Errors
{
    // Represents a specialized API response used when an unhandled exception occurs.
    public class ApiExceptionResponse : ApiResponse
    {
        // Additional technical details about the exception.
        // Typically includes stack trace information (shown only in development).
        public string? Details { get; set; }
        public ApiExceptionResponse(int statusCode, string? message = null, string? details = null)
            : base(statusCode, message)// Call base ApiResponse constructor
        {
            Details = details;
        }
    }
}
