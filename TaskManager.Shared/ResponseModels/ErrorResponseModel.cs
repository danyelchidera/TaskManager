using System.Text.Json;

namespace TaskManager.Shared.ResponseModels
{
    public class ErrorResponseModel
    {
        public int StatusCode { get; set; }
        public string? Message { get; set; }
        public override string ToString() => JsonSerializer.Serialize(this);
    }
}
