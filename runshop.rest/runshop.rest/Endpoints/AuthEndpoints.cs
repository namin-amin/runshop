using System.Net;
using AutoMapper;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using runShop.Models.models;
using runShop.rest.AuthUtils;
using runShop.rest.Dtos;
using runShop.rest.Dtos.auth;
using runShop.rest.Dtos.user;
using runShop.services.user;

namespace runShop.rest.Endpoints;
public static class AuthEndpoints
{
    public static void MapAuthEndpoints(this IEndpointRouteBuilder routeBuilder)
    {
        var group = routeBuilder.MapGroup("api/auth").WithTags("auth");

        group.MapPost("/login", RegisterUserAsync)
                                                    .Produces<ResponseSchema<AuthSuccess>>()
                                                    .Produces<ResponseSchema<string>>(StatusCodes.Status400BadRequest)
                                                    .Produces<ResponseSchema<string>>(StatusCodes.Status500InternalServerError);
        group.MapGet("", LogInUserAsync)
                                                .Produces<ResponseSchema<AuthSuccess>>()
                                                .ProducesProblem(StatusCodes.Status400BadRequest)
                                                .ProducesProblem(StatusCodes.Status500InternalServerError);

    }

    private async static Task<IResult> LogInUserAsync(
                                                [FromBody] CreateUserDto user,
                                                IMapper mapper,
                                                IUserService userService,
                                                [FromServices] JwtUtils jwtUtils
                                                )
    {
        if (user == null)
        {
            return TypedResults.BadRequest();

        }
        var newUser = mapper.Map<User>(user);

        var isValidUser = await userService.IsValidUser(newUser);

        if (!isValidUser)
            return TypedResults.BadRequest(new ResponseSchema<string>(null,
           new[] { "Could not verify the user please try again" }));

        var stringToken = jwtUtils.CreteJwtToken(newUser);

        if (string.IsNullOrWhiteSpace(stringToken))
            return TypedResults.Problem(statusCode: StatusCodes.Status500InternalServerError);

        return TypedResults.Ok(new ResponseSchema<AuthSuccess>(
            new AuthSuccess { Token = stringToken, User = mapper.Map<UserResponseDto>(newUser) }, null));
    }

    private static async Task<IResult> RegisterUserAsync([FromBody] CreateUserDto user,
                                        IValidator<CreateUserDto> validator,
                                        IUserService userService,
                                        IMapper mapper,
                                        [FromServices] JwtUtils jwtUtils)
    {
        if (user == null)
        {
            return TypedResults.BadRequest(new ResponseSchema<string>(null,
                        new[] { "provided data not valid" }));

        }
        var validationResult = validator.Validate(user);

        if (!validationResult.IsValid)
        {
            return TypedResults.BadRequest(new ResponseSchema<string>(null,
               validationResult.Errors));
        }

        var newUser = await userService.CreateNewUser(mapper.Map<User>(user));

        if (newUser is null)

            return TypedResults.
            Problem("could not create a user", statusCode: (int)HttpStatusCode.InternalServerError);

        var stringToken = jwtUtils.CreteJwtToken(newUser);

        if (string.IsNullOrWhiteSpace(stringToken))
            return TypedResults.
              Problem("could not create a user", statusCode: (int)HttpStatusCode.InternalServerError);

        return TypedResults.Ok(new ResponseSchema<AuthSuccess>(
            new AuthSuccess { Token = stringToken, User = mapper.Map<UserResponseDto>(newUser) }, null));
    }
}
