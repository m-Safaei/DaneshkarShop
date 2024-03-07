using DaneshkarShop.Application.DTOs.AdminSide.User;
using DaneshkarShop.Application.Services.Interface;
using DaneshkarShop.Domain.Entities.User;
using Microsoft.AspNetCore.Mvc;

namespace DaneshkarShop.Presentation.Areas.Admin.Controllers;

public class UsersController : AdminBaseController
{

    #region Ctor

    private readonly IUserService _userService;
    private readonly IRoleService _roleService;

    public UsersController(IUserService userService, IRoleService roleService)
    {
        _userService = userService;
        _roleService = roleService;
    }

    #endregion

    #region List of Users

    public IActionResult Index()
    {
        var users = _userService.ListOfUsersDTO();
        if (users == null) return NotFound();

        return View(users);
    }

    #endregion

    #region Edit User

    [HttpGet]
    public IActionResult EditUser(int userId)
    {
        //Get User's Information
        var userInfo = _userService.FillEditUserAdminSideDTO(userId);
        if (userInfo == null) return NotFound();

        #region View Datas

        ViewData["Roles"] = _roleService.GetListOfRoles();

        #endregion

        return View(userInfo);
    }

    [HttpPost]
    public IActionResult EditUser(EditUserAdminSideDTO model, List<int> selectedRoles)
    {
        if (ModelState.IsValid)
        {
            var res = _userService.EditUserAdminSide(model, selectedRoles);
            if (res)
            {
                return RedirectToAction(nameof(Index));
            }
        }

        #region View Datas

        ViewData["Roles"] = _roleService.GetListOfRoles();

        #endregion
        return View(model);
    }

    #endregion

    #region Detail

    public async Task<IActionResult> DetailUser(int userId, CancellationToken cancellation = default)
    {
        //Get User's Information
        var userInfo = await _userService.FillEditUserAdminSideDTOAsync(userId, cancellation);
        if (userInfo == null) return NotFound();

        #region View Datas

        ViewData["Roles"] = await _roleService.GetListOfRolesAsync(cancellation);

        #endregion

        return View(userInfo);
    }

    #endregion
}

