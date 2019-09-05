namespace Shop.Core.Interfaces
{
    public interface IJwtFactory
    {
        string GenerateEncodedToken(string userName, string email);
    }
}
