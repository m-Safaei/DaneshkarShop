using DaneshkarShop.Domain.DTOs.AdminSide.User;
using DaneshkarShop.Application.Services.Interface;
using DaneshkarShop.Presentation.HttpManager;
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

    #region Delete User

    public async Task<IActionResult> DeleteUser(int userId,CancellationToken cancellationToken)
    {
        var res = await _userService.DeleteUserAsync(userId, cancellationToken);
        if (res)
        {
            return ApiResponse.SetResponse(ApiResponseStatus.Success,null,"عملیات با موفقیت انجام شد.");
        }

        return ApiResponse.SetResponse(ApiResponseStatus.Danger,null,"عملیات با شکست مواجه شده است.");
    }

    #endregion
}

