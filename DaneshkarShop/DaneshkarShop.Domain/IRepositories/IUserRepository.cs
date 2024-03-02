using DaneshkarShop.Domain.Entities.User;

namespace DaneshkarShop.Domain.IRepositories;

public interface IUserRepository
{
    bool DoesExistUserByMobile(string mobile);

    void AddUser(User user);

    void SaveChange();
    User? GetUserByMobile(string mobile);
}

