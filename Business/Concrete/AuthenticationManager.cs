using Business.Abstract;
using Microsoft.Extensions.Configuration;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using ViewModels;

public class AuthenticationManager : IAuthenticationService
{
    private readonly ITokenService _tokenService;
    private readonly IUserService _userService;
    private readonly IConfiguration _configuration;

    public AuthenticationManager(ITokenService tokenService, IUserService userService, IConfiguration configuration)
    {
        _tokenService = tokenService;
        _userService = userService;
        _configuration = configuration;
    }

    public async Task<JwtResponse> Login(UserLoginViewModel user)
    {
        var userEntity = await _userService.GetUserByEmailAsync(user.Email);

        if (userEntity == null || !VerifyPassword(user.Password, userEntity.UserPassword))
        {
            throw new UnauthorizedAccessException("Invalid credentials");
        }

        var claims = new List<Claim>
        {
            new Claim(ClaimTypes.Name, userEntity.UserName),
            new Claim(ClaimTypes.Surname, userEntity.UserSurname),
            new Claim(ClaimTypes.Email, userEntity.UserEmail), 
            new Claim(ClaimTypes.Role, userEntity.UserRole.RoleName)
        };

        var token = _tokenService.GenerateToken(claims);

        return new JwtResponse
        {
            Token = new JwtSecurityTokenHandler().WriteToken(token),
            Expiration = token.ValidTo
        };
    }

    private bool VerifyPassword(string password, string UserPassword)
    {
        return password == UserPassword;
    }
}
