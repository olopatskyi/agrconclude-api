using System.Text.Json.Serialization;

namespace agrconclude.api.DTOs.Response
{
    public class ErrorResponse
    {
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string? PropertyName { get; set; }
        public string? Message { get; init; }

        public ErrorResponse()
        {
        }

        public ErrorResponse(string message, string? propertyName = null)
        {
            PropertyName = propertyName;
            Message = message;
        }

        public static ErrorResponse Create(string message, string? propertyName = null)
        {
            return new ErrorResponse()
            {
                PropertyName = propertyName,
                Message = message
            };
        }
    }
}
