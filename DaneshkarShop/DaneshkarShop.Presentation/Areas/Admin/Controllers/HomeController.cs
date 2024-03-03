using DaneshkarShop.Application.Services.Interface;
using DaneshkarShop.Application.Utilities;
using DaneshkarShop.Domain.Entities.Role;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DaneshkarShop.Presentation.Areas.Admin.Controllers;

[Area("Admin")]
[Authorize]
public class HomeController : Controller
{

    #region Ctor

    private readonly IRoleService _roleService;

    public HomeController(IRoleService roleService)
    {
        _roleService = roleService;
    }

    #endregion
    public IActionResult Index()
    {

        #region Check User Access

        bool permission = false;

        var userId = (int)User.GetUserId();

        List<Role> roles = _roleService.GetUserRolesByUserId(userId);

        foreach (var role in roles)
        {
            if (role.RoleUniqueName == "Admin")
            {
                permission = true;
            }
        }

        if (permission == false) return RedirectToAction("Index", "Home");

        #endregion

        return View();
    }
}

