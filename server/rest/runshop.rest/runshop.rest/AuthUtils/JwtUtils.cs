using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace runShop.rest.AuthUtils;
public class JwtUserSchema
{
    public string UserName { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string Id { get; set; } = string.Empty;
}


public static class AddJwtUtils
{
    public static IServiceCollection AddJwtUtil(this IServiceCollection services,string key)
    {
        return services.AddSingleton<IJwtUtils>(new JwtUtils(key));
    }
}


public class JwtUtils : IJwtUtils
{
    private readonly byte[] _jwtSecret;

    public JwtUtils(string key)
    {
     _jwtSecret = Encoding.ASCII.GetBytes(key);
    }

    public string CreteJwtToken(JwtUserSchema jwtUserSchema)
    { 
        var tokenDescription = new SecurityTokenDescriptor
        {
            Subject = new System.Security.Claims.ClaimsIdentity
            (
            new[]
                {
                    new Claim("id",Guid.NewGuid().ToString()),
                            new Claim(JwtRegisteredClaimNames.Sub,jwtUserSchema.UserName),
                            new Claim(JwtRegisteredClaimNames.Email,jwtUserSchema.Email),
                            new Claim(JwtRegisteredClaimNames.Jti,jwtUserSchema.Id)
                }
            ),
            Expires = DateTime.UtcNow.AddDays(2),
            SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(_jwtSecret),
                                                           SecurityAlgorithms.HmacSha512Signature)
        };


        var token = new JwtSecurityTokenHandler().CreateToken(tokenDescription);
        var jwtToken = new JwtSecurityTokenHandler().WriteToken(token);
        return jwtToken.ToString();
    }
}

