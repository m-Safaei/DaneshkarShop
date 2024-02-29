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
            bool result = _userService.RegisterUser(userDTO);
            if (result)
            {
                return RedirectToAction("Index", "Home");

            }
            
        }

        TempData["ErrorMessage"] = "کاربری با شماره موبایل وارد شده در سیستم وجود دارد.";
        return View();
    }

    #endregion

    #region Login



    #endregion

    #region Logout



    #endregion
}

