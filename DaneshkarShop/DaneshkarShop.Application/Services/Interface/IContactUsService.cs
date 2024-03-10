using DaneshkarShop.Application.DTOs.SiteSide.ContactUs;

namespace DaneshkarShop.Application.Services.Interface;

public interface IContactUsService
{
    Task AddContactUsMessage(ContactUsDTO contactUs);
}

