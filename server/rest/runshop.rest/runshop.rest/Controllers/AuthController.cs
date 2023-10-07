using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using runShop.data.unit;
using runShop.rest.Dtos.user;
using runShop.rest.Dtos.auth;
using runShop.rest.Dtos;
using runShop.rest.AuthUtils;
using AutoMapper;
using runShop.Models.models;
using runShop.services.user;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace runShop.rest.Controllers;


[Route("api/[controller]")]
[ApiController]
public class AuthController : ControllerBase
{
    private readonly IJwtUtils _jwtUtils;
    private readonly IValidator<CreateUserDto> _validator;
    private readonly IUserService _userService;
    private readonly IMapper _mapper;


    public AuthController(IJwtUtils jwtUtils, IValidator<CreateUserDto> validator, IUserService userService,IMapper mapper)
    {
        _jwtUtils = jwtUtils;
        _validator = validator;
        _userService = userService;
        _mapper = mapper;
    }

    [HttpPost("register")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ResponseSchema<AuthSuccess>))]
    [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(ResponseSchema<string>))]
    [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(ResponseSchema<string>))]
    public async Task<ActionResult> RegisterUser([FromBody] CreateUserDto user)
    {
        if (user != null)
        {
            var validationResult = _validator.Validate(user);

            if (!validationResult.IsValid)
            {
                return BadRequest(new ResponseSchema<string>(null,
                   validationResult.Errors));
            }

            var newUser = await _userService.CreateNewUser(_mapper.Map<User>(user));

            if (newUser is null)
                return StatusCode(StatusCodes.Status500InternalServerError,
                    new ResponseSchema<string>(null,
                    new[] { "could not create a user" }));

            var stringToken = _jwtUtils.CreteJwtToken(newUser);

            if (string.IsNullOrWhiteSpace(stringToken))
                return StatusCode(StatusCodes.Status500InternalServerError,
                    new ResponseSchema<string>(null,
                    new[] { "could not create a user" }));

            return Ok(new ResponseSchema<AuthSuccess>(
                new AuthSuccess { Token =  stringToken, User = _mapper.Map<UserResponseDto>(newUser)}, null));

        }
        return BadRequest(new ResponseSchema<string>(null,
                    new[] { "provided data not valid" }));
    }

    [HttpPost("login")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<ActionResult> LogIn([FromBody] CreateUserDto user)
    {
        if (user != null)
        {

            var newUser = _mapper.Map<User>(user);

            var isValidUser = await _userService.IsValidUser(newUser);

            if (!isValidUser)
                return BadRequest(new ResponseSchema<string>(null,
               new[] { "Could not verify the user please try again" }));

            var stringToken = _jwtUtils.CreteJwtToken(newUser);

            if (string.IsNullOrWhiteSpace(stringToken))
                return StatusCode(StatusCodes.Status500InternalServerError, "could not create new user");

            return Ok(stringToken);

        }
        return BadRequest();

    }


}
