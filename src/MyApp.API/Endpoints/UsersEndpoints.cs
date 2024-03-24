using MyApp.Application.Services;
using MyApp.Application.Requests;

namespace MyApp.API.Endpoints;

internal static class UsersEndpoints
{
    private const string GetByIdEndpointName = "GetUserByIdEndpoint";
    
    public static WebApplication UseUsersEndpoints(this WebApplication app)
    {
        app.MapGet("api/users", async (IUserService userService)
            => Results.Ok(await userService.GetUsers())).RequireAuthorization();

        app.MapGet("api/users/{id:Guid}", async (Guid id, IUserService userService) =>
        {
            var result = await userService.GetUser(id);
            return result is null ? Results.NotFound() : Results.Ok(result);
        }).WithName(GetByIdEndpointName);

        app.MapPost("api/users", async (AddUser request, IUserService userService) =>
        {
            var userDto = await userService.AddUser(request);
            return Results.CreatedAtRoute(GetByIdEndpointName, new {userDto.Id});
        });
        
        app.MapPost("api/signUp", async (SignUp request, IUserService userService) =>
        {
            var userId = await userService.SignUp(request);
            return Results.CreatedAtRoute(GetByIdEndpointName, new {id = userId});
        });

        return app;
    }
}