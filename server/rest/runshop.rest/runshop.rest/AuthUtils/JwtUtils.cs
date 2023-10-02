using Microsoft.IdentityModel.Tokens;
using runShop.Models.models;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace runShop.rest.AuthUtils
{
    public class JwtUserSchema
    {
        public string UserName{ get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Id { get; set; } = string.Empty;
    }


    public class JwtUtils
    {
        public string CreteJwtToken(JwtUserSchema jwtUserSchema)
        {
            var key = Encoding.ASCII.GetBytes("dhisah8ydghsahduihas8iydghuyasbgduy1276w351243e512473e123eu0812y439712h8yebg8123eg712fge7 wnhdg786awdvbgusbacuhjvsuycbsianxuisabhc8iysagd78t7q6we23q7e51234e56idbs8uyadf76awfr");

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
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key),
                                                               SecurityAlgorithms.HmacSha512Signature)
            };


            var token = new JwtSecurityTokenHandler().CreateToken(tokenDescription);
            var jwtToken = new JwtSecurityTokenHandler().WriteToken(token);
            return jwtToken.ToString();
        }
    }
}
