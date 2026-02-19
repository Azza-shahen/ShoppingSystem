namespace ShoppingSystem.API.Errors
{
    // This class represents a standardized API response structure.
    //used for handling errors in a consistent format across the API.
    public class ApiResponse
    {
        public int StatusCode { get; set; }
        public string? Message { get; set; }
        public ApiResponse(int statusCode, string? message = null)
        {
            StatusCode = statusCode;
            Message = message ?? GetDefaultMessageForStatusCode(statusCode);
        }
        private static string? GetDefaultMessageForStatusCode(int statusCode)
        {
            /*  switch (statusCode)
                 {
                     case 400:
                         return "...";
                 }*/
            return statusCode switch
            {
                400 => "A bad request — check your parameters",
                401 => "Authentication required, you are not authorized",
                403 => "Permission denied",
                404 => "Resource not found",
                409 => "Conflict with existing resource",
                422 => "Validation error — see details",
                429 => "Rate limit exceeded — try again later",
                500 => "Something went wrong on our server — we're on it",
                503 => "Service temporarily unavailable",
                // If the status code is not defined above
                _ => $"Unexpected status code: {statusCode}"
            };
        }
    }

}
