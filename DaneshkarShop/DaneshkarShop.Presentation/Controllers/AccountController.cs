using DaneshkarShop.Application.DTOs.SiteSide.Account;
using DaneshkarShop.Application.Services.Interface;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DaneshkarShop.Presentation.Controllers;

public class AccountController : Controller
{

    #region Ctor
    private readonly IUserService _userService;

    public AccountController(IUserService userService)
    {
        _userService = userService;
    }

    #endregion

    #region Register

    [HttpGet]
    public IActionResult Register()
    {
        return View();
    }

    [HttpPost, ValidateAntiForgeryToken]
    public IActionResult Register(UserRegisterDTO userDTO)
    {
        if (ModelState.IsValid)
        {
            if (_userService.DoesExistUserByMobile(userDTO.Mobile) == false)
            {
                //Object Mapping
                User1 user = new()
                {
                    UserName = userDTO.UserName,
                    Mobile = userDTO.Mobile.Trim(),
                    Password = PasswordHelper.EncodePasswordMd5(userDTO.Password)
                };
                //Add User to Database
                _context.Users.Add(user);
                _context.SaveChanges();

                return RedirectToAction("Index", "Home");
            }

        }
        return View();
    }

    #endregion

    #region Login



    #endregion

    #region Logout



    #endregion
}

