namespace agrconclude.Domain.Models
{
    public class ErrorMessage
    {
        public string? Message { get; set; }

        public string? PropertyName { get; set; }

        public ErrorMessage() { }
        
        public ErrorMessage(string message, string? propertyName = null)
        {
            Message = message;
            PropertyName = propertyName;
        }
    }
}
