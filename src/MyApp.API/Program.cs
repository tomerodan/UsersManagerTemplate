using Microsoft.AspNetCore.Identity;
using MyApp.API.Endpoints;
using MyApp.Application.Services;
using MyApp.Domain.Entities;
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
builder.Services.AddSingleton<IPasswordHasher<User>, PasswordHasher<User>>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseUsersEndpoints();

app.Run();