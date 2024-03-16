using MyApp.Application.Abstractions;
using MyApp.Application.DTO;
using MyApp.Application.Requests;
using MyApp.Domain.Entities;

namespace MyApp.Application.Services;

public class UserService : IUserService
{
    private readonly IUserRepository _userRepository;

    public UserService(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public async Task<IEnumerable<UserDto>> GetUsers()
    {
        var users = await _userRepository.GetAll();

        var usersDto = users.Select(x => new UserDto
        {
            Id = x.Id,
            Username = x.Username,
            FirstName = x.FirstName,
            LastName = x.LastName
        });
        
        return usersDto;
    }

    public async Task<UserDto> GetUser(Guid id)
    {
        var user = await _userRepository.GetById(id);
        var userDto = new UserDto
        {
            Id = user.Id,
            Username = user.Username,
            FirstName = user.FirstName,
            LastName = user.LastName
        };
        
        return userDto;
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

        await _userRepository.Add(newUser);

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
