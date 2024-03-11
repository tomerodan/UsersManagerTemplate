using Microsoft.EntityFrameworkCore;
using MyApp.API.DTO;
using MyApp.API.Requests;

namespace MyApp.API.Services;

public class UserService : IUserService
{
    private readonly ApplicationDbContext _dbContext;

    public UserService(
        ApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<IEnumerable<UserDto>> GetUsers()
    {
        var users = await _dbContext.Users.Select(x => new UserDto
        {
            Id = x.Id,
            Username = x.Username,
            FirstName = x.FirstName,
            LastName = x.LastName
        }).ToListAsync();
        return users;
    }

    public async Task<UserDto> GetUser(Guid id)
    {
        var user = await _dbContext.Users.Where(x => x.Id == id).Select(x => new UserDto
        {
            Id = x.Id,
            Username = x.Username,
            FirstName = x.FirstName,
            LastName = x.LastName
        }).FirstOrDefaultAsync();
        return user;
    }

    public async Task<UserDto> AddUser(AddUser addUserRequest)
    {
        var newUser = new User()
        {
            Id = Guid.NewGuid(),
            Username = addUserRequest.Username,
            FirstName = addUserRequest.FirstName,
            LastName = addUserRequest.LastName
        };

        await _dbContext.Users.AddAsync(newUser);
        await _dbContext.SaveChangesAsync();

        var userDto = new UserDto
        {
            Id = newUser.Id,
            Username = newUser.Username,
            FirstName = newUser.FirstName,
            LastName = newUser.LastName
        };
        
        return userDto;
    }
}
