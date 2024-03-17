using MyApp.Application.Requests;
using MyApp.Application.Services;
using MyApp.Infrastructure.DAL;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// builder.Services.AddDbContext<ApplicationDbContext>(
//     x => x.UseNpgsql(builder.Configuration.GetConnectionString("MyDatabase")));
builder.Services.AddPostgresDatabase();

builder.Services.AddScoped<IUserService, UserService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapGet("api/users", async (IUserService userService) => Results.Ok(await userService.GetUsers()));

app.MapGet("api/users/{id:Guid}", async (Guid id, IUserService userService) =>
{
    var result = await userService.GetUser(id);
    return result is null ? Results.NotFound() : Results.Ok(result);
}).WithName("GetUserByIdEndpoint");

app.MapPost("api/users", async (AddUser request, IUserService userService) =>
{
    var userDto = await userService.AddUser(request);
    return Results.CreatedAtRoute("GetUserByIdEndpoint", new {userDto.Id});
});

app.Run();