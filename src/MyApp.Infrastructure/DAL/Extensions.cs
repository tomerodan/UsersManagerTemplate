using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using MyApp.Application.Abstractions;
using MyApp.Infrastructure.DAL.Repositories;

namespace MyApp.Infrastructure.DAL;

public static class Extensions
{
    public static IServiceCollection AddPostgresDatabase(this IServiceCollection services)
    {
        var connectionString = "Host=localhost;Database=MyDatabase;Username=postgres;Password=";
        services.AddDbContext<ApplicationDbContext>(x => x.UseNpgsql(connectionString));

        services.AddScoped<IUserRepository, UserRepository>();
        return services;
    }
}