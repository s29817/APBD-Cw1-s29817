using APBD_Cw1_s29817.Exceptions;
using APBD_Cw1_s29817.Models;

namespace APBD_Cw1_s29817.Services.Users;

public class UserService : IUserService
{
    private readonly List<User> _users = [];

    public void Add(User user)
    {
        _users.Add(user);
    }

    public User GetById(int userId)
    {
        return _users.FirstOrDefault(user => user.Id == userId)
               ?? throw new NotFoundException($"User with id {userId} was not found.");
    }

    public IReadOnlyCollection<User> GetAll()
    {
        return _users.AsReadOnly();
    }
}