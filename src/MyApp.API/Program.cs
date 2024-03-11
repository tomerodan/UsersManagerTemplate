using Microsoft.EntityFrameworkCore;
using MyApp.API;
using MyApp.API.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<ApplicationDbContext>(
    x => x.UseNpgsql(builder.Configuration.GetConnectionString("MyDatabase")));

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
});

app.Run();