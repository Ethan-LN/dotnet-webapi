using BuberDinner.Application.Common.Errors;
using BuberDinner.Application.Common.Interfaces.Authentication;
using BuberDinner.Application.Common.Interfaces.Persistence;
using BuberDinner.Domain.Entities;
using FluentResults;


namespace BuberDinner.Application.Services.Authentication;

public class AuthenticationService : IAuthenticationService
{
  private readonly IJwtTokenGenerator _jwtTokenGenerator;
  private readonly IUserRepository _userRepository;

  public AuthenticationService(IJwtTokenGenerator jwtTokenGenerator, IUserRepository userRepository)
  {
    _jwtTokenGenerator = jwtTokenGenerator;
    _userRepository = userRepository;
  }

  public Result<AuthenticationResult> Register(string firstName, string lastName, string email, string password)
  {
    // 1. validate the user doesn't exit
    if (_userRepository.GetUserByEmail(email) is not null)
    {
      return Result.Fail<AuthenticationResult>(new [] { new DuplicateEmailError() });
    }

    // 2. Create user (generate unique ID) & Persist to DB
    var user = new User { FirstName = firstName, LastName = lastName, Email = email, Password = password };

    _userRepository.Add(user);

    // 3. Create JWT token
    var token = _jwtTokenGenerator.GenerateToken(user);

    return new AuthenticationResult(user, token);
  }
  public AuthenticationResult Login(string email, string password)
  {
    // 1. validate the user exists
    if (_userRepository.GetUserByEmail(email) is not User user)
    {
      throw new Exception("User with given email doesn't exists");
    }
    // 2. Validate the password is correct
    if (user.Password != password)
    {
      throw new Exception("Invalid password");
    }

    // 3. Create JWT token

    var token = _jwtTokenGenerator.GenerateToken(user);
    return new AuthenticationResult(user, token);
  }
}