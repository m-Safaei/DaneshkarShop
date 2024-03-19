using DaneshkarShop.Domain.Entities.ContactUs;

namespace DaneshkarShop.Domain.IRepositories;

public interface IContactUsRepository
{
    Task SaveChangeAsync();
    Task AddContactUsToDatabase(ContactUs contactUs);
    Task<List<ContactUs>> GetListOfContactUs();
    Task<ContactUs?> GetContactUsById(int id);
    void DeleteContactUs(ContactUs contactUs);
}

