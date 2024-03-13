using MyApp.Application.DTO;
using MyApp.Application.Requests;

namespace MyApp.Application.Services;

public interface IUserService
{
    Task<IEnumerable<UserDto>> GetUsers();
    Task<UserDto> GetUser(Guid id);
    Task<UserDto> AddUser(AddUser addUserRequest);

}