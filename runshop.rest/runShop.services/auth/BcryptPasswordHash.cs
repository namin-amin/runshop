namespace runShop.services.auth;

public class BcryptPasswordHash : IPassWordHash
{
    private string _secretHash { get; set; }

    public BcryptPasswordHash(string hash)
    {
        _secretHash = hash; //Todo Change this
    }

    public bool VerifyPassword(string password)
    {
        return BCrypt.Net.BCrypt.Verify(password, _secretHash);
    }

    public string GetHashedPassword(string password)
        //Todo  need to implement salt and hash 
    {
        return BCrypt.Net.BCrypt.HashPassword(password,6);
    }
}
