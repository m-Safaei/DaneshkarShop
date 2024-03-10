using DaneshkarShop.Application.DTOs.SiteSide.ContactUs;
using DaneshkarShop.Application.Services.Interface;
using DaneshkarShop.Domain.Entities.ContactUs;
using DaneshkarShop.Domain.IRepositories;

namespace DaneshkarShop.Application.Services.Implementation;

public class ContactUsService : IContactUsService
{

    #region Ctor
    private readonly IContactUsRepository _contactUsRepository;

    public ContactUsService(IContactUsRepository contactUsRepository)
    {
        _contactUsRepository = contactUsRepository;
    }

    #endregion

    public async Task AddContactUsMessage(ContactUsDTO contactUs)
    {
        // Object Mapping 
        ContactUs model = new()
        {
            Username = contactUs.Username,
            Mobile = contactUs.Mobile,
            Message = contactUs.Message
        };
        await _contactUsRepository.AddContactUsToDatabase(model);
        await _contactUsRepository.SaveChangeAsync();
    }
}

