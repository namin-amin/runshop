using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace runShop.rest.AuthUtils;
public static class AddBearerService
{
    /// <summary>
    /// Adds JWT bearer Auth
    /// </summary>
    /// <param name="services">service reference</param>
    /// <param name="key">secret key required to hash password</param>
    /// <returns></returns>
    public static IServiceCollection AddBearer(this IServiceCollection services, string key)
    {
        services.AddAuthentication(options =>
        {
            options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
            options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
        }).AddJwtBearer(o =>
        {
            o.TokenValidationParameters = new TokenValidationParameters
            {
                ValidateIssuer = false,
                IssuerSigningKey = new SymmetricSecurityKey
                (Encoding.UTF8.GetBytes(key)),
                ValidateLifetime = true,
                ValidateAudience = false,
                ValidateIssuerSigningKey = true
            };


        }).AddCookie(CookieAuthenticationDefaults.AuthenticationScheme, o =>
        {
            o.ExpireTimeSpan = TimeSpan.FromDays(1);
        });
        return services;
    }
}
