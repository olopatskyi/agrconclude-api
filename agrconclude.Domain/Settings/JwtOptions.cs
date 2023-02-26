namespace agrconclude.Domain.Settings
{
    public interface IJwtOptions
    {
        string Issuer { get; }
        string Audience { get; }
        string Key { get; }
        
        int ExpireMinutes { get; }
    }

    public class JwtOptions : IJwtOptions
    {
        public const string SectionName = "JwtConfig";

        public string Issuer { get; set; } = null!;
        public string Audience { get; set; } = null!;
        public string Key { get; set; } = null!;
        
        public int ExpireMinutes { get; set; }
    }
}