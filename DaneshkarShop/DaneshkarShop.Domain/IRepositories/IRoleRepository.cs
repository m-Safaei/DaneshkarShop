using DaneshkarShop.Domain.Entities.Role;

namespace DaneshkarShop.Domain.IRepositories;

public interface IRoleRepository
{
    List<Role> GetUserRolesByUserId(int userId);

    List<Role> GetListOfRoles();
    Task<List<Role>> GetListOfRolesAsync(CancellationToken cancellationToken);
    void AddUserSelectedRoleData(UserSelectedRole userSelectedRole);

    void SaveChange();
}

