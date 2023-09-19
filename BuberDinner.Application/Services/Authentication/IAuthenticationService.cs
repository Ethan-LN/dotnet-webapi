using ErrorOr;
namespace BuberDinner.Application.Services.Authentication;

public interface IAuthenticationService
{
  ErrorOr<AuthenticationResult> Register(string firstname, string lastname, string email, string password);
  AuthenticationResult Login(string email, string password);
}