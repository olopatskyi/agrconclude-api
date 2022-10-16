namespace agrconclude.core.Settings
{
    public interface IAuthSettings
    {
        string? Issuer { get; set; }
        string? Audience { get; set; }
        string? Key { get; set; }
    }

    public class AuthSettings : IAuthSettings
    {
        public const string SectionName = "Authentication";

        public string? Issuer { get; set; }
        public string? Audience { get; set; }
        public string? Key { get; set; }
    }
}
