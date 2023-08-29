using Microsoft.Extensions.DependencyInjection;
using BuberDinner.Application.Services.Authentication;

namespace BuberDinner.Infrastructure;
public static class DependencyIjenction
{
  public static IServiceCollection AddInfrastructure(this IServiceCollection services)
  {
        services.AddScoped<IAuthenticationService, AuthenticationService>();
        return services;
  }
}