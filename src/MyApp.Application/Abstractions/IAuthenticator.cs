using MyApp.Application.DTO;

namespace MyApp.Application.Abstractions;

public interface IAuthenticator
{
    JwtDto CreateToken(Guid userId);
}