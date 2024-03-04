﻿using DaneshkarShop.Domain.Entities.Role;

namespace DaneshkarShop.Application.Services.Interface;

public interface IRoleService
{
    List<Role> GetUserRolesByUserId(int userId);
    bool IsUserAdmin(int userId);
}

