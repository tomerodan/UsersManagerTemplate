using Microsoft.EntityFrameworkCore;
using MyApp.Application.Abstractions;
using MyApp.Domain.Entities;

namespace MyApp.Infrastructure.DAL.Repositories;

internal class UserRepository(ApplicationDbContext dbContext) : IUserRepository
{
    public async Task<IEnumerable<User>> GetAll()
        => await dbContext.Users.ToListAsync();

    public Task<User> GetById(Guid id)
        => dbContext.Users.SingleOrDefaultAsync(x => x.Id == id);

    public async Task Add(User user)
        => await dbContext.AddAsync(user);
}