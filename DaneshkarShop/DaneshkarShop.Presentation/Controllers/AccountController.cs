using System.Security.Claims;
using DaneshkarShop.Domain.DTOs.SiteSide.Account;
using DaneshkarShop.Application.Services.Interface;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
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

    [HttpGet]
    public IActionResult Login(string? ReturnUrl)
    {
        UserLoginDTO returnModel = new UserLoginDTO();
        if (!string.IsNullOrEmpty(ReturnUrl))
        {
            returnModel.ReturnUrl = ReturnUrl;
        }
        return View(returnModel);
    }

    [HttpPost, ValidateAntiForgeryToken]
    public async Task<IActionResult> Login(UserLoginDTO userDTO)
    {
        if (ModelState.IsValid)
        {
            // دریافت کاربر برای ست کردن کوکی
            var user = _userService.GetUserByMobile(userDTO.Mobile);
            if (user != null)
            {
                //Set Cookie
                var claims = new List<Claim>
                {
                    new (ClaimTypes.NameIdentifier, user.UserId.ToString()),
                    new (ClaimTypes.MobilePhone, user.Mobile),
                    new (ClaimTypes.Name, user.Username),
                };

                var claimIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                var principal = new ClaimsPrincipal(claimIdentity);

                var authProps = new AuthenticationProperties();
                //authProps.IsPersistent = model.RememberMe;

                await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal, authProps);

                if (!string.IsNullOrEmpty(userDTO.ReturnUrl))
                {
                    return Redirect(userDTO.ReturnUrl);
                }

                return RedirectToAction("Index", "Home");

            }
        }

        TempData["ErrorMessage"] = "کاربری با مشخصات وارد شده یافت نشد.";
        return View();
    }

    #endregion

    #region Logout

    [HttpGet("Logout")]
    public async Task<IActionResult> Logout()
    {
        await HttpContext.SignOutAsync();

        return RedirectToAction("Index", "Home");
    }
    #endregion

    #region CheckUserRoleForLogin

    public IActionResult ManageUserForLogin()
    {
        if (!User.Identity.IsAuthenticated)
        {
            return RedirectToAction(nameof(Login));
        }

        return RedirectToAction(nameof(Logout));
    }

    #endregion
}

