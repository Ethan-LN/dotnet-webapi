
using BuberDinner.Application.Common.Errors;
using FluentResults;

namespace BuberDinner.Application.Services.Authentication;

public interface IAuthenticationService
{
  Result<AuthenticationResult> Register(string firstname, string lastname, string email, string password);
  AuthenticationResult Login(string email, string password);
}