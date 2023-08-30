using System.Security.Claims;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.VisualBasic;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using BuberDinner.Application.Common.Interfaces.Authentication;


namespace BuberDinner.Infrastructure.Authentication;

public class JwdTokenGenerator : IJwtTokenGenerator
{

  public string GenerateToken(Guid userId, string firstName, string lastName)
  {

    var signingCredentials = new SigningCredentials(
        new SymmetricSecurityKey(
          Encoding.UTF8.GetBytes("super-secret-key")),
          SecurityAlgorithms.HmacSha256);
    var claims = new[]
    {
      new Claim(JwtRegisteredClaimNames.Sub, userId.ToString()),
      new Claim(JwtRegisteredClaimNames.GivenName, firstName),
      new Claim(JwtRegisteredClaimNames.FamilyName, lastName),
      new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
    };

    var securityToken = new JwtSecurityToken(
      issuer: "BuberDinner",
      expires: DateTime.Now.AddDays(1),
      claims: claims,
      signingCredential: signingCredentials;
      );

    return new JwtSecurityTokenHandler().WriteToken(securityToken);
  }
}