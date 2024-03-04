using DaneshkarShop.Application.Services.Interface;
using DaneshkarShop.Domain.Entities.User;
using Microsoft.AspNetCore.Mvc;

namespace DaneshkarShop.Presentation.Areas.Admin.Controllers;

public class UsersController : AdminBaseController
{

    #region Ctor

    private readonly IUserService _userService;

    public UsersController(IUserService userService)
    {
        _userService = userService;
    }

    #endregion

    #region List of Users

    public IActionResult Index()
    {
        List<User> users = _userService.ListOfUsers();
        if (users == null) return NotFound();

        return View(users);
    }

    #endregion
}

