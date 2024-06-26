using Microsoft.AspNetCore.Identity;
using MyApp.API.Endpoints;
using MyApp.Application.Abstractions;
using MyApp.Application.Services;
using MyApp.Domain.Entities;
using MyApp.Infrastructure;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddControllers();
builder.Services.AddInfrastructure(builder.Configuration);

builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddSingleton<IPasswordHasher<User>, PasswordHasher<User>>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthentication();
app.UseUsersEndpoints();

app.MapGet("getJwt", (IAuthenticator authenticator) =>
{
    var testId = Guid.NewGuid();
    var token = authenticator.CreateToken(testId);
    return Results.Ok(token);
});

app.Run();