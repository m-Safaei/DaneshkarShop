using DaneshkarShop.Application.Services.Implementation;
using DaneshkarShop.Application.Services.Interface;
using DaneshkarShop.Presentation.HttpManager;
using Microsoft.AspNetCore.Mvc;

namespace DaneshkarShop.Presentation.Areas.Admin.Controllers;

public class ContactUsController : AdminBaseController
{

    #region Ctor

    private readonly IContactUsService _contactUsService;

    public ContactUsController(IContactUsService contactUsService)
    {
        _contactUsService = contactUsService;
    }

    #endregion

    #region List of ContactUs

    public async Task<IActionResult> ContactUsList()
    {
        return View(await _contactUsService.GetListOfContactUs());
    }

    #endregion

    #region ContactUs Detail

    [HttpGet]
    public async Task<IActionResult> ContactUsDetail(int id)
    {
        return View(await _contactUsService.GetContactUsById(id));
    }

    #endregion

    #region Delete ContactUs

    public async Task<IActionResult> DeleteContactUs(int id, CancellationToken cancellationToken)
    {
        var res = await _contactUsService.DeleteContactUs(id);
        if (res)
        {
            return ApiResponse.SetResponse(ApiResponseStatus.Success, null, "عملیات با موفقیت انجام شد.");
        }

        return ApiResponse.SetResponse(ApiResponseStatus.Danger, null, "عملیات با شکست مواجه شده است.");
    }

    #endregion
}

