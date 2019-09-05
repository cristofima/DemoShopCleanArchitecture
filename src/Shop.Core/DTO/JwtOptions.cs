namespace Shop.Core.DTO
{
    public class JwtOptions
    {
        public string Key { get; set; }
        public string Issuer { get; set; }
        public int ValidForMinutes { get; set; }
    }
}
