using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MyApp.Application.Abstractions;
using MyApp.Infrastructure.DAL.Repositories;

namespace MyApp.Infrastructure.DAL;

public static class Extensions
{
    public static IServiceCollection AddPostgresDatabase(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<ApplicationDbContext>(x => x.UseNpgsql(
            configuration.GetConnectionString("MyDatabase")));

        services.AddHostedService<DatabaseInitializer>();
        
        services.AddScoped<IUserRepository, UserRepository>();
        return services;
    }
}