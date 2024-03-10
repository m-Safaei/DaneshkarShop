using DaneshkarShop.Application.DTOs.SiteSide.ContactUs;
using DaneshkarShop.Application.Services.Interface;
using Microsoft.AspNetCore.Mvc;

namespace DaneshkarShop.Presentation.Controllers;

public class ContactUsController : Controller
{

    #region Ctor

    private readonly IContactUsService _contactUsService;

    public ContactUsController(IContactUsService contactUsService)
    {
        _contactUsService = contactUsService;
    }
    #endregion

    [HttpGet]
    public IActionResult ContactUs()
    {
        return View();
    }

    [HttpPost, ValidateAntiForgeryToken]
    public async Task<IActionResult> ContactUs(ContactUsDTO model)
    {
        #region Add ContactUs

        if (ModelState.IsValid)
        {
            await _contactUsService.AddContactUsMessage(model);
            return RedirectToAction("Index", "Home");
        }

        #endregion

        return View(model);
    }
}

