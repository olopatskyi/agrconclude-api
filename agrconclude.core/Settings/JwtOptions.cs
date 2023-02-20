namespace agrconclude.core.Settings
{
    public interface IJwtOptions
    {
        string Issuer { get; }
        string Audience { get; }
        string Key { get; }
    }

    public class JwtOptions : IJwtOptions
    {
        public const string SectionName = "JwtConfig";

        public string Issuer { get; set; }
        public string Audience { get; set; }
        public string Key { get; set; }
    }
}