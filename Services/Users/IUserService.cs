using APBD_Cw1_s29817.Models;

namespace APBD_Cw1_s29817.Services.Users;

public interface IUserService
{
    void Add(User user);
    User GetById(int userId);
    IReadOnlyCollection<User> GetAll();
}