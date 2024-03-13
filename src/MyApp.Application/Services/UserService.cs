using MyApp.Application.DTO;
using MyApp.Application.Requests;

namespace MyApp.Application.Services;

public class UserService : IUserService
{
    //private readonly ApplicationDbContext _dbContext;

    public UserService()
    {

    }

    // public async Task<IEnumerable<UserDto>> GetUsers()
    // {
    //     var users = await _dbContext.Users.Select(x => new UserDto
    //     {
    //         Id = x.Id,
    //         Username = x.Username,
    //         FirstName = x.FirstName,
    //         LastName = x.LastName
    //     }).ToListAsync();
    //     return users;
    // }

    // public async Task<UserDto> GetUser(Guid id)
    // {
    //     var user = await _dbContext.Users.Where(x => x.Id == id).Select(x => new UserDto
    //     {
    //         Id = x.Id,
    //         Username = x.Username,
    //         FirstName = x.FirstName,
    //         LastName = x.LastName
    //     }).FirstOrDefaultAsync();
    //     return user;
    // }

    /*public async Task<UserDto> AddUser(AddUser addUserRequest)
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
    }*/
    
    public Task<IEnumerable<UserDto>> GetUsers()
    {
        throw new NotImplementedException();
    }

    public Task<UserDto> GetUser(Guid id)
    {
        throw new NotImplementedException();
    }

    public Task<UserDto> AddUser(AddUser addUserRequest)
    {
        throw new NotImplementedException();
    }
}
