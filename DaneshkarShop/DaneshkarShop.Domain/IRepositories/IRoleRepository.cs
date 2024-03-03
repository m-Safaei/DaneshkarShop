using DaneshkarShop.Domain.Entities.Role;

namespace DaneshkarShop.Domain.IRepositories;

public interface IRoleRepository
{
    List<Role> GetUserRolesByUserId(int userId);
}

