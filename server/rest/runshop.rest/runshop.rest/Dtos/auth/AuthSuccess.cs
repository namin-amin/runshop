using runShop.rest.Dtos.user;

namespace runShop.rest.Dtos.auth;

public class AuthSuccess
{
    public string Token { get; set; } = string.Empty;
    public UserResponseDto User { get; set; }
}

