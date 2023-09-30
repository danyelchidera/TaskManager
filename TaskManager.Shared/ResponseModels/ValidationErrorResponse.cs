namespace TaskManager.Shared.ResponseModels
{
    public sealed class ValidationErrorResponse
    {
        public int StatusCode { get; set; }
        public List<string>? ErrorMessages { get; set; }
    }
}
