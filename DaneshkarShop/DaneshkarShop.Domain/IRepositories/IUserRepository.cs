using DaneshkarShop.Domain.Entities.User;

namespace DaneshkarShop.Domain.IRepositories;

public interface IUserRepository
{
    #region General Methods

    bool DoesExistUserByMobile(string mobile);

    void AddUser(User user);

    void SaveChange();
    User? GetUserByMobile(string mobile);
    User? GetUserById(int userId);
    

    #endregion

    #region Admin Side Methods

    List<User> ListOfUsers();

    #endregion
}

