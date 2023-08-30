using Microsoft.Extensions.DependencyInjection;
using BuberDinner.Application.Services.Authentication;
using BuberDinner.Application.Common.Interfaces.Authentication;
using BuberDinner.Infrastructure.Authentication;

namespace BuberDinner.Infrastructure;
public static class DependencyIjenction
{
  public static IServiceCollection AddInfrastructure(this IServiceCollection services)
  {
        services.AddScoped<IAuthenticationService, AuthenticationService>();
        services.AddSingleton<IJwtTokenGenerator, JwtTokenGenerator>();
        return services;
  }
}