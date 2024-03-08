using WebAPI.DTO;
using WebAPI.Requests;

namespace WebAPI.Services;

public interface IUserService
{
    Task<IEnumerable<UserDto>> GetUsers();
    Task<UserDto> GetUser(Guid Id);
    Task<UserDto> AddUser(AddUser addUserRequest);

}