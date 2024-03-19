using DaneshkarShop.Application.Services.Interface;
using DaneshkarShop.Domain.DTOs.SiteSide.ContactUs;
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

    public async Task<List<ContactUs>> GetListOfContactUs()
    {
        return await _contactUsRepository.GetListOfContactUs();
    }

    public async Task<ContactUs?> GetContactUsById(int id)
    {
        return await _contactUsRepository.GetContactUsById(id);
    }

    public async Task<bool> DeleteContactUs(int id)
    {
        //Get ContactUs by id
        var contactUs = await GetContactUsById(id);
        if (contactUs == null) return false;
        
        //Delete ContactUS
        _contactUsRepository.DeleteContactUs(contactUs);

        //SaveChange method
        await _contactUsRepository.SaveChangeAsync();
        return true;

    }
}

