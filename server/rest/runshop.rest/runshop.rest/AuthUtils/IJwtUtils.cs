namespace runShop.rest.AuthUtils
{
    public interface IJwtUtils
    {
        string CreteJwtToken(JwtUserSchema jwtUserSchema);
    }
}