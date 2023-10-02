using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using runShop.Models.models;
using runShop.rest.AuthUtils;
using runShop.rest.Dto.user;
using runShop.rest.Dtos;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace runShop.rest.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly JwtUtils _jwtUtils;

        public AuthController(JwtUtils jwtUtils)
        {
            this._jwtUtils = jwtUtils;
        }

        [HttpPost("/register")]
        [ProducesResponseType(StatusCodes.Status200OK,Type = typeof(ResponseDto<string>))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(ResponseDto<string>))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(ResponseDto<string>))]
        public ActionResult RegisterUser([FromBody] CreateUserDto user)
        {
            if (user != null)
            {

                var stringToken = _jwtUtils.CreteJwtToken(new JwtUserSchema
                {
                    Id = Guid.NewGuid().ToString(),
                    Email = user.Email,
                    UserName = user.FirstName
                });

                if (string.IsNullOrWhiteSpace(stringToken))
                    return StatusCode(StatusCodes.Status500InternalServerError,
                        new ResponseDto<string>(null, 
                        new[] { "could not create a user" }));

                return Ok(new ResponseDto<string>(stringToken,null));

            }
            return BadRequest(new ResponseDto<string>(null,
                        new[] { "provided data not valid" }));
        }

        [HttpPost("/login")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult LogIn([FromBody] CreateUserDto user) {
            if (user != null)
            {

                var stringToken = _jwtUtils.CreteJwtToken(new JwtUserSchema
                {
                    Id = Guid.NewGuid().ToString(),
                    Email = user.Email,
                    UserName = user.FirstName
                });

                if (string.IsNullOrWhiteSpace(stringToken))
                    return StatusCode(StatusCodes.Status500InternalServerError, "could not create new user");

                return Ok(stringToken);

            }
            return BadRequest();

        }


    }
}
