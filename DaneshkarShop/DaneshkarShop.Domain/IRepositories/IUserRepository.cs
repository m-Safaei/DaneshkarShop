using DaneshkarShop.Domain.Entities.Role;
using DaneshkarShop.Domain.Entities.User;

namespace DaneshkarShop.Domain.IRepositories;

public interface IUserRepository
{
    #region General Methods

    bool DoesExistUserByMobile(string mobile);

    void AddUser(User user);

    void SaveChange();
    Task SaveChangeAsync(CancellationToken cancellationToken);
    User? GetUserByMobile(string mobile);
    User? GetUserById(int userId);
    Task<User?> GetUserByIdAsync(int userId,CancellationToken cancellation);
    void UpdateUser(User user);
    #endregion

    #region Admin Side Methods

    Task<int> GetCountOfActiveUsers(CancellationToken cancellation);
    List<User> ListOfUsers();
    IQueryable<User> QueryableUsers();
    List<int> GetListOfUserRolesIdByUserId(int userId);
    Task<List<int>> GetListOfUserRolesIdByUserIdAsync(int userId,CancellationToken cancellation);
    List<UserSelectedRole> GetListOfUserSelectedRolesByUserId(int userId);
    void DeleteRangeOfUserSelectedRoles(List<UserSelectedRole> userSelectedRoles);

    #endregion
}

