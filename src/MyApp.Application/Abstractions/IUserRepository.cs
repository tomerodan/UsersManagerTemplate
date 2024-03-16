using MyApp.Domain.Entities;

namespace MyApp.Application.Abstractions;

public interface IUserRepository
{
    Task<IEnumerable<User>> GetAll();
    Task<User> GetById(Guid id);
    Task Add(User user);
}