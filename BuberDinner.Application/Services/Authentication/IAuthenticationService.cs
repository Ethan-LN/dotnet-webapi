
using BuberDinner.Application.Common.Errors;
using OneOf;

namespace BuberDinner.Application.Services.Authentication;

public interface IAuthenticationService
{
  AuthenticationResult Register(string firstname, string lastname, string email, string password);
  AuthenticationResult Login(string email, string password);
}