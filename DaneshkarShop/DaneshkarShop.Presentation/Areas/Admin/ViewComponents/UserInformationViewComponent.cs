using DaneshkarShop.Application.Services.Interface;
using Microsoft.AspNetCore.Mvc;

namespace DaneshkarShop.Presentation.Areas.Admin.ViewComponents;

public class UserInformationViewComponent : ViewComponent
{

    #region Ctor
    private readonly IUserService _userService;

    public UserInformationViewComponent(IUserService userService)
    {
        _userService = userService;
    }

    #endregion

    public async Task<IViewComponentResult> InvokeAsync(CancellationToken cancellationToken)
    {
        return View("UserInformation", await _userService.FillLandingPageModelDTO(cancellationToken));
    }
}

