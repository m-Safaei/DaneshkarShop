using DaneshkarShop.Application.Services.Interface;
using Microsoft.AspNetCore.Mvc;

namespace DaneshkarShop.Presentation.Areas.Admin.Controllers;


public class HomeController : AdminBaseController
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

        //#region Check User Access

        //bool permission = false;

        //var userId = (int)User.GetUserId();

        //List<Role> roles = _roleService.GetUserRolesByUserId(userId);

        //foreach (var role in roles)
        //{
        //    if (role.RoleUniqueName == "Admin")
        //    {
        //        permission = true;
        //    }
        //}

        //if (permission == false) return RedirectToAction("Index", "Home");

        //#endregion

        return View();
    }
}

