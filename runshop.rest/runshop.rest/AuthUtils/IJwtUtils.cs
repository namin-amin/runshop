using runShop.Models.models;

namespace runShop.rest.AuthUtils
{
    public interface IJwtUtils
    {
        string CreteJwtToken(User jwtUser);
    }
}