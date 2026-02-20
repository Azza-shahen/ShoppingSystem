namespace ShoppingSystem.API.Errors
{
    // Represents a specialized API response for validation errors.
    // Inherits from ApiResponse and always returns HTTP 400.
    public sealed class ApiValidationErrorResponse : ApiResponse
    {
        public IEnumerable<string> Errors { get; set; }
        public ApiValidationErrorResponse()
            : base(400)
        {
            Errors = new List<string>();
        }
    }
}
