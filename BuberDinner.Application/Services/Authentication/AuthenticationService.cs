using System.Runtime.CompilerServices;
using BuberDinner.Application.Common.Interfaces.Authentication;

namespace BuberDinner.Application.Services.Authentication;

public class AuthenticationService : IAuthenticationService
{
  private readonly IJwtTokenGenerator _jwtTokenGenerator;
  public AuthenticationResult Register(string firstname, string lastname, string email, string password)
  {
    // Check if user already exists

    // Create user (generate unique ID)
    Guid userId = Guid.NewGuid();

    // Create JWT token
    var token = _jwtTokenGenerator.GenerateToken(userId, firstName, lastName);

    return new AuthenticationResult(userId, firstname, lastname, email, token);
  }
  public AuthenticationResult Login(string email, string password)
  {
    return new AuthenticationResult(Guid.NewGuid(), "firstName", "lastName", email, "token");
  }
}