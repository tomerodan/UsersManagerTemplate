using MyApp.API.DTO;
using MyApp.API.Requests;

namespace MyApp.API.Services;

public interface IUserService
{
    Task<IEnumerable<UserDto>> GetUsers();
    Task<UserDto> GetUser(Guid Id);
    Task<UserDto> AddUser(AddUser addUserRequest);

}