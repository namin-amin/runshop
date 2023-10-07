using AutoMapper;
using FluentValidation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using runShop.Models.models;
using runShop.rest.Dtos.user;
using runShop.services.user;
using System.Net.Mime;

namespace runShop.rest.Controllers;

[Route("api/[controller]")]
[ApiController]
[Authorize]
public class UserController : ControllerBase
{
    private readonly IUserService _userService;
    private readonly IMapper _mapper;


    public UserController(IUserService userService, IMapper mapper, IValidator<CreateUserDto> validator)
    {
        _userService = userService;
        _mapper = mapper;
    }


    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [Produces(MediaTypeNames.Application.Json)]
    [AllowAnonymous]
    public async Task<ActionResult<IEnumerable<User>>> GetAllUsers()
    {
        var users = await _userService.GetAllUsersAsync();
        return Ok(_mapper.Map<IEnumerable<User>, IEnumerable<UserResponseDto>>(users));
    }



    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(bool))]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<bool>> DeleteUser([FromRoute] ulong id)
    {
        if (await _userService.DeleteUserAsync(id))
        {
            return Ok(true);
        }
        return NotFound();
    }


}
