using Microsoft.Extensions.DependencyInjection;
using BuberDinner.Application.Services.Authentication;

namespace BuberDinner.Application;
public static class DependencyIjenction
{
  public static IServiceCollection AddApplication(this IServiceCollection services)
  {
        services.AddScoped<IAuthenticationService, AuthenticationService>();
        return services;
  }
}