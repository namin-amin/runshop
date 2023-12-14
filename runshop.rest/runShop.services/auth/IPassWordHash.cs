namespace runShop.services.auth;

public interface IPassWordHash
{
    public string GetHashedPassword(string password);
    public bool VerifyPassword(string password);
}
