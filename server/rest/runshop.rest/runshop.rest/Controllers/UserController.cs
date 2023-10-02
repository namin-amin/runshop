using AutoMapper;
using FluentValidation;
using FluentValidation.Results;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using runShop.Models.models;
using runShop.rest.Dto.user;
using runShop.rest.Dtos.user;
using runShop.services.user;
using System.Net.Mime;

namespace runShop.rest.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class UserController : ControllerBase
    {
        private readonly IUserService userService;
        private readonly IMapper _mapper;
        private readonly IValidator<CreateUserDto> validator;

        public UserController(IUserService userService, IMapper mapper, IValidator<CreateUserDto> validator)
        {
            this.userService = userService;
            this._mapper = mapper;
            this.validator = validator;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [Produces(MediaTypeNames.Application.Json)]
        [AllowAnonymous]
        public async Task<ActionResult<IEnumerable<User>>> GetUsers()
        {
            var users = await userService.GetAllUsersAsync();
            return Ok(_mapper.Map<IEnumerable<User>, IEnumerable<UserResponseDto>>(users));
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type =typeof(bool))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<bool>> DeleteUser([FromRoute]ulong id)
        {
            if (await userService.DeleteUserAsync(id))
            {
                return Ok(true);
            }
            return NotFound();  
        }

        [HttpPost]
        [Produces(MediaTypeNames.Application.Json)]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(User))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(IEnumerable<ValidationFailure>))]
        public ActionResult GetUser([FromBody]CreateUserDto user)
        {
            var validationResult = validator.Validate(user);

            if (!validationResult.IsValid)
            {
                return BadRequest(validationResult.Errors);
            }

            var a =  _mapper.Map<User>(user);
            
            return Ok(a);

        }

    }
}
