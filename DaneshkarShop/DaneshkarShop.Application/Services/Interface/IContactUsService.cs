using DaneshkarShop.Domain.DTOs.SiteSide.ContactUs;
using DaneshkarShop.Domain.Entities.ContactUs;

namespace DaneshkarShop.Application.Services.Interface;

public interface IContactUsService
{
    Task AddContactUsMessage(ContactUsDTO contactUs);
    Task<List<ContactUs>> GetListOfContactUs();
    Task<ContactUs?> GetContactUsById(int id);
    Task<bool> DeleteContactUs(int id);
    Task ChangeMessageState(ContactUs contactUs, CancellationToken cancellationToken);
}

