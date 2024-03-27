using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using MyApp.Domain.Entities;

namespace MyApp.Infrastructure.DAL;

internal sealed class DatabaseInitializer : IHostedService
{
    private readonly IServiceProvider _serviceProvider;
    
    public DatabaseInitializer(IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider;
    }
    
    public async Task StartAsync(CancellationToken cancellationToken)
    {
        using (var scope = _serviceProvider.CreateScope())
        {
            var dbContext = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
            await dbContext.Database.MigrateAsync(cancellationToken);

            if (!await dbContext.Users.AnyAsync(cancellationToken))
            {
                await dbContext.Users.AddAsync(new User()
                {
                    Id = Guid.Parse("c2782a57-513e-4f72-ba6c-8345b86f3ef7"),
                    Username = "testUsername",
                    FirstName = "testFirstName",
                    LastName = "testLastName",
                    PasswordHash =
                        "AQAAAAIAAYagAAAAEAxuWJVel/TLzzpu2p8J+iTGLMnuGAQuAgWwFSMH6ncIUq3WUjLEdbjCwN/H6r6nrg==",
                    Email = "test@example.com"
                }, cancellationToken);

                await dbContext.SaveChangesAsync(cancellationToken);
            }
        };
    }

    public Task StopAsync(CancellationToken cancellationToken) => Task.CompletedTask;
}