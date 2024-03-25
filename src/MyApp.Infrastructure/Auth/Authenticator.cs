using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using MyApp.Application.Abstractions;
using MyApp.Application.DTO;

namespace MyApp.Infrastructure.Auth;

internal sealed class Authenticator : IAuthenticator
{
    private readonly AuthOptions _authOptions;
    private readonly JwtSecurityTokenHandler _jwtSecurityToken = new JwtSecurityTokenHandler();
    
    public Authenticator(IOptions<AuthOptions> authOptions)
    {
        _authOptions = authOptions.Value;
    }
    
    public JwtDto CreateToken(Guid userId)
    {
        var now = DateTime.Now;
        var expiry = _authOptions.Expiry ?? TimeSpan.FromHours(1);
        var expires = now.Add(expiry);
        
        var signingCredentials = new SigningCredentials(
            new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_authOptions.SecretSigningKey)),
            SecurityAlgorithms.HmacSha256);
        
        var claims = new List<Claim>()
        {
            new Claim("userId", userId.ToString())
        };

        var jwt = new JwtSecurityToken(_authOptions.Issuer, _authOptions.Audience, claims, now, expires,
            signingCredentials);

        var accessToken = _jwtSecurityToken.WriteToken(jwt);

        return new JwtDto()
        {
            AccessToken = accessToken
        };
    }
}