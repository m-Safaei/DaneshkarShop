using DaneshkarShop.Application.Services.Interface;
using DaneshkarShop.Domain.Entities.Role;
using DaneshkarShop.Domain.IRepositories;
using System.Data;
using System.Security;

namespace DaneshkarShop.Application.Services.Implementation;

public class RoleService : IRoleService
{
    
    #region Ctor

    private readonly IRoleRepository _roleRepository;
    private readonly IUserRepository _userRepository;

    public RoleService(IRoleRepository roleRepository,IUserRepository userRepository)
    {
        _roleRepository = roleRepository;
        _userRepository = userRepository;
    }

    #endregion

    public List<Role> GetUserRolesByUserId(int userId)
    {
        return _roleRepository.GetUserRolesByUserId(userId);
    }

    public bool IsUserAdmin(int userId)
    {
        //Get user by Id
        var user = _userRepository.GetUserById(userId);
        if (user.SuperAdmin) return true;

        var userRoles = GetUserRolesByUserId(userId);

        foreach (var role in userRoles)
        {
            if (role.RoleUniqueName == "Admin")
            {
                return true;
            }
        }
        return false;
    }
}

