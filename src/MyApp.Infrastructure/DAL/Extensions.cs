using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace MyApp.Infrastructure.DAL;

public static class Extensions
{
    public static IServiceCollection AddPostgresDatabase(this IServiceCollection services)
    {
        var connectionString = "Host=localhost;Database=MyDatabase;Username=postgres;Password=";
        services.AddDbContext<ApplicationDbContext>(x => x.UseNpgsql(connectionString));
        return services;
    }
}