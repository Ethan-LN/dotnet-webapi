using BuberDinner.Application.Common.Interfaces.Persistence;
using BuberDinner.Domain.Entities;

namespace BuberDinner.Infrastructure.Persistence;

public class UserRepository : IUserRepository
{
  private static readonly List<User> _user = new();
  public User? GetUserByEmail(string email)
  {
   return  _user.SingleOrDefault(user => user.Email == email);
  }
  public void Add(User user)
  {
    _user.Add(user);
  }
}