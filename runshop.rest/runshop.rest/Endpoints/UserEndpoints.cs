using AutoMapper;
using runShop.Models.models;
using runShop.rest.Dtos.user;
using runShop.services.user;
using System.Net;

namespace runShop.rest.Endpoints;
public static class UserEndpoints
{
    public static void MapUserEndpoints(this IEndpointRouteBuilder routeBuilder)
    {
        var group = routeBuilder.MapGroup("api/user").WithTags("user");

        group.MapGet("/", GetAllUsers)
                                                .Produces<IEnumerable<UserResponseDto>>();

        group.MapGet("/{id}", DeleteUser)
                                                .Produces<bool>()
                                                .ProducesProblem((int)HttpStatusCode.NotFound);
    }

    private static async Task<IResult> GetAllUsers(IUserService userService, IMapper mapper)
    {
        var users = await userService.GetAllUsersAsync();
        return TypedResults.Ok(mapper.Map<IEnumerable<User>, IEnumerable<UserResponseDto>>(users));
    }

    private static async Task<IResult> DeleteUser(ulong id, IUserService userService)
    {
        if (await userService.DeleteUserAsync(id))
        {
            return TypedResults.Ok(true);
        }
        return TypedResults.NotFound();
    }
}
