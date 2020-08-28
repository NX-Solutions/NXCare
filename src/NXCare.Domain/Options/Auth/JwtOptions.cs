namespace NXCare.Domain.Options.Auth
{
    public class JwtOptions
    {
        public const string SectionName = "Jwt";

        public string Issuer { get; set; }

        public string Secret { get; set; }

        public string Audience { get; set; }
    }
}